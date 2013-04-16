//DOM-Extension helper
jQuery.webshims.register('dom-extend', function($, webshims, window, document, undefined){
	"use strict";
	
	webshims.assumeARIA = Modernizr.localstorage || Modernizr.video || Modernizr.boxsizing;
	
	if($('<form />').attr('novalidate') === "" || ('required' in $('<input />')[0].attributes)){
		webshims.error("IE browser modes are busted in IE10. Please test your HTML/CSS/JS with a real IE version or at least IETester or similiar tools");
	}
	
	if(!$.parseHTML){
		webshims.error("Webshims needs jQuery 1.8+ to work properly. Please update your jQuery version or downgrade webshims.");
	}

	//shortcus
	var modules = webshims.modules;
	var listReg = /\s*,\s*/;
		
	//proxying attribute
	var olds = {};
	var havePolyfill = {};
	var extendedProps = {};
	var extendQ = {};
	var modifyProps = {};
	
	var oldVal = $.fn.val;
	var singleVal = function(elem, name, val, pass, _argless){
		return (_argless) ? oldVal.call($(elem)) : oldVal.call($(elem), val);
	};
	

	$.fn.val = function(val){
		var elem = this[0];
		if(arguments.length && val == null){
			val = '';
		}
		if(!arguments.length){
			if(!elem || elem.nodeType !== 1){return oldVal.call(this);}
			return $.prop(elem, 'value', val, 'val', true);
		}
		if($.isArray(val)){
			return oldVal.apply(this, arguments);
		}
		var isFunction = $.isFunction(val);
		return this.each(function(i){
			elem = this;
			if(elem.nodeType === 1){
				if(isFunction){
					var genVal = val.call( elem, i, $.prop(elem, 'value', undefined, 'val', true));
					if(genVal == null){
						genVal = '';
					}
					$.prop(elem, 'value', genVal, 'val') ;
				} else {
					$.prop(elem, 'value', val, 'val');
				}
			}
		});
	};
	$.fn.onTrigger = function(evt, fn){
		return this.on(evt, fn).each(fn);
	};
	
	var dataID = '_webshimsLib'+ (Math.round(Math.random() * 1000));
	var elementData = function(elem, key, val){
		elem = elem.jquery ? elem[0] : elem;
		if(!elem){return val || {};}
		var data = $.data(elem, dataID);
		if(val !== undefined){
			if(!data){
				data = $.data(elem, dataID, {});
			}
			if(key){
				data[key] = val;
			}
		}
		
		return key ? data && data[key] : data;
	};


	[{name: 'getNativeElement', prop: 'nativeElement'}, {name: 'getShadowElement', prop: 'shadowElement'}, {name: 'getShadowFocusElement', prop: 'shadowFocusElement'}].forEach(function(data){
		$.fn[data.name] = function(){
			return this.map(function(){
				var shadowData = elementData(this, 'shadowData');
				return shadowData && shadowData[data.prop] || this;
			});
		};
	});
	
	if($.Tween.propHooks._default){
		$.extend($.Tween.propHooks._default, {
			get: function( tween ) {
				var result;
				
				if ( (tween.elem[ tween.prop ] != null || havePolyfill[ tween.prop ]) &&
					(!tween.elem.style || tween.elem.style[ tween.prop ] == null) ) {
					return havePolyfill[ tween.prop ] ? $.prop(tween.elem, tween.prop) : tween.elem[ tween.prop ];
				}
	
				// passing an empty string as a 3rd parameter to .css will automatically
				// attempt a parseFloat and fallback to a string if the parse fails
				// so, simple values such as "10px" are parsed to Float.
				// complex values such as "rotate(1rad)" are returned as is.
				result = jQuery.css( tween.elem, tween.prop, "" );
				// Empty strings, null, undefined and "auto" are converted to 0.
				return !result || result === "auto" ? 0 : result;
			},
			set: function( tween ) {
				// use step hook for back compat - use cssHook if its there - use .style if its
				// available and use plain properties where available
				if ( jQuery.fx.step[ tween.prop ] ) {
					jQuery.fx.step[ tween.prop ]( tween );
				} else if ( tween.elem.style && ( tween.elem.style[ jQuery.cssProps[ tween.prop ] ] != null || jQuery.cssHooks[ tween.prop ] ) ) {
					jQuery.style( tween.elem, tween.prop, tween.now + tween.unit );
				} else if( !havePolyfill[ tween.prop ] ) {
					tween.elem[ tween.prop ] = tween.now;
				} else {
					$.prop(tween.elem, tween.prop, tween.now);
				}
			}
		});
	}
	
	
	['removeAttr', 'prop', 'attr'].forEach(function(type){
		olds[type] = $[type];
		$[type] = function(elem, name, value, pass, _argless){
			var isVal = (pass == 'val');
			var oldMethod = !isVal ? olds[type] : singleVal;
			if( !elem || !havePolyfill[name] || elem.nodeType !== 1 || (!isVal && pass && type == 'attr' && $.attrFn[name]) ){
				return oldMethod(elem, name, value, pass, _argless);
			}
			
			var nodeName = (elem.nodeName || '').toLowerCase();
			var desc = extendedProps[nodeName];
			var curType = (type == 'attr' && (value === false || value === null)) ? 'removeAttr' : type;
			var propMethod;
			var oldValMethod;
			var ret;
			
			
			if(!desc){
				desc = extendedProps['*'];
			}
			if(desc){
				desc = desc[name];
			}
			
			if(desc){
				propMethod = desc[curType];
			}
			
			if(propMethod){
				if(name == 'value'){
					oldValMethod = propMethod.isVal;
					propMethod.isVal = isVal;
				}
				if(curType === 'removeAttr'){
					return propMethod.value.call(elem);	
				} else if(value === undefined){
					return (propMethod.get) ? 
						propMethod.get.call(elem) : 
						propMethod.value
					;
				} else if(propMethod.set) {
					if(type == 'attr' && value === true){
						value = name;
					}
					
					ret = propMethod.set.call(elem, value);
				}
				if(name == 'value'){
					propMethod.isVal = oldValMethod;
				}
			} else {
				ret = oldMethod(elem, name, value, pass, _argless);
			}
			if((value !== undefined || curType === 'removeAttr') && modifyProps[nodeName] && modifyProps[nodeName][name]){
				
				var boolValue;
				if(curType == 'removeAttr'){
					boolValue = false;
				} else if(curType == 'prop'){
					boolValue = !!(value);
				} else {
					boolValue = true;
				}
				
				modifyProps[nodeName][name].forEach(function(fn){
					if(!fn.only || (fn.only = 'prop' && type == 'prop') || (fn.only == 'attr' && type != 'prop')){
						fn.call(elem, value, boolValue, (isVal) ? 'val' : curType, type);
					}
				});
			}
			return ret;
		};
		
		extendQ[type] = function(nodeName, prop, desc){
			
			if(!extendedProps[nodeName]){
				extendedProps[nodeName] = {};
			}
			if(!extendedProps[nodeName][prop]){
				extendedProps[nodeName][prop] = {};
			}
			var oldDesc = extendedProps[nodeName][prop][type];
			var getSup = function(propType, descriptor, oDesc){
				if(descriptor && descriptor[propType]){
					return descriptor[propType];
				}
				if(oDesc && oDesc[propType]){
					return oDesc[propType];
				}
				if(type == 'prop' && prop == 'value'){
					return function(value){
						var elem = this;
						return (desc.isVal) ? 
							singleVal(elem, prop, value, false, (arguments.length === 0)) : 
							olds[type](elem, prop, value)
						;
					};
				}
				if(type == 'prop' && propType == 'value' && desc.value.apply){
					return  function(value){
						var sup = olds[type](this, prop);
						if(sup && sup.apply){
							sup = sup.apply(this, arguments);
						} 
						return sup;
					};
				}
				return function(value){
					return olds[type](this, prop, value);
				};
			};
			extendedProps[nodeName][prop][type] = desc;
			if(desc.value === undefined){
				if(!desc.set){
					desc.set = desc.writeable ? 
						getSup('set', desc, oldDesc) : 
						(webshims.cfg.useStrict && prop == 'prop') ? 
							function(){throw(prop +' is readonly on '+ nodeName);} : 
							function(){webshims.info(prop +' is readonly on '+ nodeName);}
					;
				}
				if(!desc.get){
					desc.get = getSup('get', desc, oldDesc);
				}
				
			}
			
			['value', 'get', 'set'].forEach(function(descProp){
				if(desc[descProp]){
					desc['_sup'+descProp] = getSup(descProp, oldDesc);
				}
			});
		};
		
	});
	
	var extendNativeValue = (function(){
		var UNKNOWN = webshims.getPrototypeOf(document.createElement('foobar'));
		var has = Object.prototype.hasOwnProperty;
		//see also: https://github.com/lojjic/PIE/issues/40 | https://prototype.lighthouseapp.com/projects/8886/tickets/1107-ie8-fatal-crash-when-prototypejs-is-loaded-with-rounded-cornershtc
		var isExtendNativeSave = Modernizr.advancedObjectProperties && Modernizr.objectAccessor;
		return function(nodeName, prop, desc){
			var elem , elemProto;
			 if( isExtendNativeSave && (elem = document.createElement(nodeName)) && (elemProto = webshims.getPrototypeOf(elem)) && UNKNOWN !== elemProto && ( !elem[prop] || !has.call(elem, prop) ) ){
				var sup = elem[prop];
				desc._supvalue = function(){
					if(sup && sup.apply){
						return sup.apply(this, arguments);
					}
					return sup;
				};
				elemProto[prop] = desc.value;
			} else {
				desc._supvalue = function(){
					var data = elementData(this, 'propValue');
					if(data && data[prop] && data[prop].apply){
						return data[prop].apply(this, arguments);
					}
					return data && data[prop];
				};
				initProp.extendValue(nodeName, prop, desc.value);
			}
			desc.value._supvalue = desc._supvalue;
		};
	})();
		
	var initProp = (function(){
		
		var initProps = {};
		
		webshims.addReady(function(context, contextElem){
			var nodeNameCache = {};
			var getElementsByName = function(name){
				if(!nodeNameCache[name]){
					nodeNameCache[name] = $(context.getElementsByTagName(name));
					if(contextElem[0] && $.nodeName(contextElem[0], name)){
						nodeNameCache[name] = nodeNameCache[name].add(contextElem);
					}
				}
			};
			
			
			$.each(initProps, function(name, fns){
				getElementsByName(name);
				if(!fns || !fns.forEach){
					webshims.warn('Error: with '+ name +'-property. methods: '+ fns);
					return;
				}
				fns.forEach(function(fn){
					nodeNameCache[name].each(fn);
				});
			});
			nodeNameCache = null;
		});
		
		var tempCache;
		var emptyQ = $([]);
		var createNodeNameInit = function(nodeName, fn){
			if(!initProps[nodeName]){
				initProps[nodeName] = [fn];
			} else {
				initProps[nodeName].push(fn);
			}
			if($.isDOMReady){
				(tempCache || $( document.getElementsByTagName(nodeName) )).each(fn);
			}
		};
		
		var elementExtends = {};
		return {
			createTmpCache: function(nodeName){
				if($.isDOMReady){
					tempCache = tempCache || $( document.getElementsByTagName(nodeName) );
				}
				return tempCache || emptyQ;
			},
			flushTmpCache: function(){
				tempCache = null;
			},
			content: function(nodeName, prop){
				createNodeNameInit(nodeName, function(){
					var val =  $.attr(this, prop);
					if(val != null){
						$.attr(this, prop, val);
					}
				});
			},
			createElement: function(nodeName, fn){
				createNodeNameInit(nodeName, fn);
			},
			extendValue: function(nodeName, prop, value){
				createNodeNameInit(nodeName, function(){
					$(this).each(function(){
						var data = elementData(this, 'propValue', {});
						data[prop] = this[prop];
						this[prop] = value;
					});
				});
			}
		};
	})();
		
	var createPropDefault = function(descs, removeType){
		if(descs.defaultValue === undefined){
			descs.defaultValue = '';
		}
		if(!descs.removeAttr){
			descs.removeAttr = {
				value: function(){
					descs[removeType || 'prop'].set.call(this, descs.defaultValue);
					descs.removeAttr._supvalue.call(this);
				}
			};
		}
		if(!descs.attr){
			descs.attr = {};
		}
	};
	
	$.extend(webshims, {

		getID: (function(){
			var ID = new Date().getTime();
			return function(elem){
				elem = $(elem);
				var id = elem.prop('id');
				if(!id){
					ID++;
					id = 'ID-'+ ID;
					elem.eq(0).prop('id', id);
				}
				return id;
			};
		})(),
		implement: function(elem, type){
			var data = elementData(elem, 'implemented') || elementData(elem, 'implemented', {});
			if(data[type]){
				webshims.info(type +' already implemented for element #'+elem.id);
				return false;
			}
			data[type] = true;
			return true;
		},
		extendUNDEFProp: function(obj, props){
			$.each(props, function(name, prop){
				if( !(name in obj) ){
					obj[name] = prop;
				}
			});
		},
		//http://www.w3.org/TR/html5/common-dom-interfaces.html#reflect
		createPropDefault: createPropDefault,
		data: elementData,
		moveToFirstEvent: function(elem, eventType, bindType){
			var events = ($._data(elem, 'events') || {})[eventType];
			var fn;
			
			if(events && events.length > 1){
				fn = events.pop();
				if(!bindType){
					bindType = 'bind';
				}
				if(bindType == 'bind' && events.delegateCount){
					events.splice( events.delegateCount, 0, fn);
				} else {
					events.unshift( fn );
				}
				
				
			}
			elem = null;
		},
		addShadowDom: (function(){
			var resizeTimer;
			var lastHeight;
			var lastWidth;
			
			var docObserve = {
				init: false,
				runs: 0,
				test: function(){
					var height = docObserve.getHeight();
					var width = docObserve.getWidth();
					
					if(height != docObserve.height || width != docObserve.width){
						docObserve.height = height;
						docObserve.width = width;
						docObserve.handler({type: 'docresize'});
						docObserve.runs++;
						if(docObserve.runs < 9){
							setTimeout(docObserve.test, 90);
						}
					} else {
						docObserve.runs = 0;
					}
				},
				handler: function(e){
					clearTimeout(resizeTimer);
					resizeTimer = setTimeout(function(){
						if(e.type == 'resize'){
							var width = $(window).width();
							var height = $(window).width();
							if(height == lastHeight && width == lastWidth){
								return;
							}
							lastHeight = height;
							lastWidth = width;
							
							docObserve.height = docObserve.getHeight();
							docObserve.width = docObserve.getWidth();
							
						}
						$(document).triggerHandler('updateshadowdom');
					}, (e.type == 'resize') ? 50 : 9);
				},
				_create: function(){
					$.each({ Height: "getHeight", Width: "getWidth" }, function(name, type){
						var body = document.body;
						var doc = document.documentElement;
						docObserve[type] = function(){
							return Math.max(
								body[ "scroll" + name ], doc[ "scroll" + name ],
								body[ "offset" + name ], doc[ "offset" + name ],
								doc[ "client" + name ]
							);
						};
					});
				},
				start: function(){
					if(!this.init && document.body){
						this.init = true;
						this._create();
						this.height = docObserve.getHeight();
						this.width = docObserve.getWidth();
						setInterval(this.test, 600);
						$(this.test);
						webshims.ready('WINDOWLOAD', this.test);
						$(window).bind('resize', this.handler);
						(function(){
							var oldAnimate = $.fn.animate;
							var animationTimer;
							
							$.fn.animate = function(){
								clearTimeout(animationTimer);
								animationTimer = setTimeout(function(){
									docObserve.test();
								}, 99);
								
								return oldAnimate.apply(this, arguments);
							};
						})();
					}
				}
			};
			
			
			webshims.docObserve = function(){
				webshims.ready('DOM', function(){
					docObserve.start();
				});
			};
			return function(nativeElem, shadowElem, opts){
				opts = opts || {};
				if(nativeElem.jquery){
					nativeElem = nativeElem[0];
				}
				if(shadowElem.jquery){
					shadowElem = shadowElem[0];
				}
				var nativeData = $.data(nativeElem, dataID) || $.data(nativeElem, dataID, {});
				var shadowData = $.data(shadowElem, dataID) || $.data(shadowElem, dataID, {});
				var shadowFocusElementData = {};
				if(!opts.shadowFocusElement){
					opts.shadowFocusElement = shadowElem;
				} else if(opts.shadowFocusElement){
					if(opts.shadowFocusElement.jquery){
						opts.shadowFocusElement = opts.shadowFocusElement[0];
					}
					shadowFocusElementData = $.data(opts.shadowFocusElement, dataID) || $.data(opts.shadowFocusElement, dataID, shadowFocusElementData);
				}
				
				nativeData.hasShadow = shadowElem;
				shadowFocusElementData.nativeElement = shadowData.nativeElement = nativeElem;
				shadowFocusElementData.shadowData = shadowData.shadowData = nativeData.shadowData = {
					nativeElement: nativeElem,
					shadowElement: shadowElem,
					shadowFocusElement: opts.shadowFocusElement
				};
				if(opts.shadowChilds){
					opts.shadowChilds.each(function(){
						elementData(this, 'shadowData', shadowData.shadowData);
					});
				}
				
				if(opts.data){
					shadowFocusElementData.shadowData.data = shadowData.shadowData.data = nativeData.shadowData.data = opts.data;
				}
				opts = null;
				webshims.docObserve();
			};
		})(),
		propTypes: {
			standard: function(descs, name){
				createPropDefault(descs);
				if(descs.prop){return;}
				descs.prop = {
					set: function(val){
						descs.attr.set.call(this, ''+val);
					},
					get: function(){
						return descs.attr.get.call(this) || descs.defaultValue;
					}
				};
				
			},
			"boolean": function(descs, name){
				
				createPropDefault(descs);
				if(descs.prop){return;}
				descs.prop = {
					set: function(val){
						if(val){
							descs.attr.set.call(this, "");
						} else {
							descs.removeAttr.value.call(this);
						}
					},
					get: function(){
						return descs.attr.get.call(this) != null;
					}
				};
			},
			"src": (function(){
				var anchor = document.createElement('a');
				anchor.style.display = "none";
				return function(descs, name){
					
					createPropDefault(descs);
					if(descs.prop){return;}
					descs.prop = {
						set: function(val){
							descs.attr.set.call(this, val);
						},
						get: function(){
							var href = this.getAttribute(name);
							var ret;
							if(href == null){return '';}
							
							anchor.setAttribute('href', href+'' );
							
							if(!$.support.hrefNormalized){
								try {
									$(anchor).insertAfter(this);
									ret = anchor.getAttribute('href', 4);
								} catch(er){
									ret = anchor.getAttribute('href', 4);
								}
								$(anchor).detach();
							}
							return ret || anchor.href;
						}
					};
				};
			})(),
			enumarated: function(descs, name){
					
					createPropDefault(descs);
					if(descs.prop){return;}
					descs.prop = {
						set: function(val){
							descs.attr.set.call(this, val);
						},
						get: function(){
							var val = (descs.attr.get.call(this) || '').toLowerCase();
							if(!val || descs.limitedTo.indexOf(val) == -1){
								val = descs.defaultValue;
							}
							return val;
						}
					};
				}
			
//			,unsignedLong: $.noop
//			,"doubble": $.noop
//			,"long": $.noop
//			,tokenlist: $.noop
//			,settableTokenlist: $.noop
		},
		reflectProperties: function(nodeNames, props){
			if(typeof props == 'string'){
				props = props.split(listReg);
			}
			props.forEach(function(prop){
				webshims.defineNodeNamesProperty(nodeNames, prop, {
					prop: {
						set: function(val){
							$.attr(this, prop, val);
						},
						get: function(){
							return $.attr(this, prop) || '';
						}
					}
				});
			});
		},
		defineNodeNameProperty: function(nodeName, prop, descs){
			havePolyfill[prop] = true;
						
			if(descs.reflect){
				webshims.propTypes[descs.propType || 'standard'](descs, prop);
			}
			
			['prop', 'attr', 'removeAttr'].forEach(function(type){
				var desc = descs[type];
				if(desc){
					if(type === 'prop'){
						desc = $.extend({writeable: true}, desc);
					} else {
						desc = $.extend({}, desc, {writeable: true});
					}
						
					extendQ[type](nodeName, prop, desc);
					if(nodeName != '*' && webshims.cfg.extendNative && type == 'prop' && desc.value && $.isFunction(desc.value)){
						extendNativeValue(nodeName, prop, desc);
					}
					descs[type] = desc;
				}
			});
			if(descs.initAttr){
				initProp.content(nodeName, prop);
			}
			return descs;
		},
		
		defineNodeNameProperties: function(name, descs, propType, _noTmpCache){
			var olddesc;
			for(var prop in descs){
				if(!_noTmpCache && descs[prop].initAttr){
					initProp.createTmpCache(name);
				}
				if(propType){
					if(descs[prop][propType]){
						//webshims.log('override: '+ name +'['+prop +'] for '+ propType);
					} else {
						descs[prop][propType] = {};
						['value', 'set', 'get'].forEach(function(copyProp){
							if(copyProp in descs[prop]){
								descs[prop][propType][copyProp] = descs[prop][copyProp];
								delete descs[prop][copyProp];
							}
						});
					}
				}
				descs[prop] = webshims.defineNodeNameProperty(name, prop, descs[prop]);
			}
			if(!_noTmpCache){
				initProp.flushTmpCache();
			}
			return descs;
		},
		
		createElement: function(nodeName, create, descs){
			var ret;
			if($.isFunction(create)){
				create = {
					after: create
				};
			}
			initProp.createTmpCache(nodeName);
			if(create.before){
				initProp.createElement(nodeName, create.before);
			}
			if(descs){
				ret = webshims.defineNodeNameProperties(nodeName, descs, false, true);
			}
			if(create.after){
				initProp.createElement(nodeName, create.after);
			}
			initProp.flushTmpCache();
			return ret;
		},
		onNodeNamesPropertyModify: function(nodeNames, props, desc, only){
			if(typeof nodeNames == 'string'){
				nodeNames = nodeNames.split(listReg);
			}
			if($.isFunction(desc)){
				desc = {set: desc};
			}
			
			nodeNames.forEach(function(name){
				if(!modifyProps[name]){
					modifyProps[name] = {};
				}
				if(typeof props == 'string'){
					props = props.split(listReg);
				}
				if(desc.initAttr){
					initProp.createTmpCache(name);
				}
				props.forEach(function(prop){
					if(!modifyProps[name][prop]){
						modifyProps[name][prop] = [];
						havePolyfill[prop] = true;
					}
					if(desc.set){
						if(only){
							desc.set.only =  only;
						}
						modifyProps[name][prop].push(desc.set);
					}
					
					if(desc.initAttr){
						initProp.content(name, prop);
					}
				});
				initProp.flushTmpCache();
				
			});
		},
		defineNodeNamesBooleanProperty: function(elementNames, prop, descs){
			if(!descs){
				descs = {};
			}
			if($.isFunction(descs)){
				descs.set = descs;
			}
			webshims.defineNodeNamesProperty(elementNames, prop, {
				attr: {
					set: function(val){
						this.setAttribute(prop, val);
						if(descs.set){
							descs.set.call(this, true);
						}
					},
					get: function(){
						var ret = this.getAttribute(prop);
						return (ret == null) ? undefined : prop;
					}
				},
				removeAttr: {
					value: function(){
						this.removeAttribute(prop);
						if(descs.set){
							descs.set.call(this, false);
						}
					}
				},
				reflect: true,
				propType: 'boolean',
				initAttr: descs.initAttr || false
			});
		},
		contentAttr: function(elem, name, val){
			if(!elem.nodeName){return;}
			var attr;
			if(val === undefined){
				attr = (elem.attributes[name] || {});
				val = attr.specified ? attr.value : null;
				return (val == null) ? undefined : val;
			}
			
			if(typeof val == 'boolean'){
				if(!val){
					elem.removeAttribute(name);
				} else {
					elem.setAttribute(name, name);
				}
			} else {
				elem.setAttribute(name, val);
			}
		},
		
//		set current Lang:
//			- webshims.activeLang(lang:string);
//		get current lang
//			- webshims.activeLang();
//		get current lang
//			webshims.activeLang({
//				register: moduleName:string,
//				callback: callback:function
//			});
//		get/set including removeLang
//			- webshims.activeLang({
//				module: moduleName:string,
//				callback: callback:function,
//				langObj: languageObj:array/object
//			});
		activeLang: (function(){
			var callbacks = [];
			var registeredCallbacks = {};
			var currentLang;
			var shortLang;
			var notLocal = /:\/\/|^\.*\//;
			var loadRemoteLang = function(data, lang, options){
				var langSrc;
				if(lang && options && $.inArray(lang, options.availabeLangs || []) !== -1){
					data.loading = true;
					langSrc = options.langSrc;
					if(!notLocal.test(langSrc)){
						langSrc = webshims.cfg.basePath+langSrc;
					}
					webshims.loader.loadScript(langSrc+lang+'.js', function(){
						if(data.langObj[lang]){
							data.loading = false;
							callLang(data, true);
						} else {
							$(function(){
								if(data.langObj[lang]){
									callLang(data, true);
								}
								data.loading = false;
							});
						}
					});
					return true;
				}
				return false;
			};
			var callRegister = function(module){
				if(registeredCallbacks[module]){
					registeredCallbacks[module].forEach(function(data){
						data.callback(currentLang, shortLang, '');
					});
				}
			};
			var callLang = function(data, _noLoop){
				if(data.activeLang != currentLang && data.activeLang !== shortLang){
					var options = modules[data.module].options;
					if( data.langObj[currentLang] || (shortLang && data.langObj[shortLang]) ){
						data.activeLang = currentLang;
						data.callback(data.langObj[currentLang] || data.langObj[shortLang], currentLang);
						callRegister(data.module);
					} else if( !_noLoop &&
						!loadRemoteLang(data, currentLang, options) && 
						!loadRemoteLang(data, shortLang, options) && 
						data.langObj[''] && data.activeLang !== '' ) {
						data.activeLang = '';
						data.callback(data.langObj[''], currentLang);
						callRegister(data.module);
					}
				}
			};
			
			
			var activeLang = function(lang){
				
				if(typeof lang == 'string' && lang !== currentLang){
					currentLang = lang;
					shortLang = currentLang.split('-')[0];
					if(currentLang == shortLang){
						shortLang = false;
					}
					$.each(callbacks, function(i, data){
						callLang(data);
					});
				} else if(typeof lang == 'object'){
					
					if(lang.register){
						if(!registeredCallbacks[lang.register]){
							registeredCallbacks[lang.register] = [];
						}
						registeredCallbacks[lang.register].push(lang);
						lang.callback(currentLang, shortLang, '');
					} else {
						if(!lang.activeLang){
							lang.activeLang = '';
						}
						callbacks.push(lang);
						callLang(lang);
					}
				}
				return currentLang;
			};
			
			return activeLang;
		})()
	});
	
	$.each({
		defineNodeNamesProperty: 'defineNodeNameProperty',
		defineNodeNamesProperties: 'defineNodeNameProperties',
		createElements: 'createElement'
	}, function(name, baseMethod){
		webshims[name] = function(names, a, b, c){
			if(typeof names == 'string'){
				names = names.split(listReg);
			}
			var retDesc = {};
			names.forEach(function(nodeName){
				retDesc[nodeName] = webshims[baseMethod](nodeName, a, b, c);
			});
			return retDesc;
		};
	});
	
	webshims.isReady('webshimLocalization', true);
});
//html5a11y
(function($, document){
	if(!$.webshims.assumeARIA || ('content' in document.createElement('template'))){return;}
	
	$(function(){
		var main = $('main').attr({role: 'main'});
		if(main.length > 1){
			webshims.error('only one main element allowed in document');
		} else if(main.is('article *, section *')) {
			webshims.error('main not allowed inside of article/section elements');
		}
	});
	
	if(('hidden' in document.createElement('a'))){
		return;
	}
	
	var elemMappings = {
		article: "article",
		aside: "complementary",
		section: "region",
		nav: "navigation",
		address: "contentinfo"
	};
	var addRole = function(elem, role){
		var hasRole = elem.getAttribute('role');
		if (!hasRole) {
			elem.setAttribute('role', role);
		}
	};
	
	
	$.webshims.addReady(function(context, contextElem){
		$.each(elemMappings, function(name, role){
			var elems = $(name, context).add(contextElem.filter(name));
			for (var i = 0, len = elems.length; i < len; i++) {
				addRole(elems[i], role);
			}
		});
		if (context === document) {
			var header = document.getElementsByTagName('header')[0];
			var footers = document.getElementsByTagName('footer');
			var footerLen = footers.length;
			
			if (header && !$(header).closest('section, article')[0]) {
				addRole(header, 'banner');
			}
			if (!footerLen) {
				return;
			}
			var footer = footers[footerLen - 1];
			if (!$(footer).closest('section, article')[0]) {
				addRole(footer, 'contentinfo');
			}
		}
	});
	
})(jQuery, document);

//additional tests for partial implementation of forms features
(function($){
	"use strict";
	var isWebkit = 'webkitURL' in window;
	var Modernizr = window.Modernizr;
	var webshims = $.webshims;
	var bugs = webshims.bugs;
	var form = $('<form action="#" style="width: 1px; height: 1px; overflow: hidden;"><select name="b" required="" /><input required="" name="a" /></form>');
	var testRequiredFind = function(){
		if(form[0].querySelector){
			try {
				bugs.findRequired = !(form[0].querySelector('select:required'));
			} catch(er){
				bugs.findRequired = false;
			}
		}
	};
	var inputElem = $('input', form).eq(0);
	var onDomextend = function(fn){
		webshims.loader.loadList(['dom-extend']);
		webshims.ready('dom-extend', fn);
	};
	
	bugs.findRequired = false;
	bugs.validationMessage = false;
	
	webshims.capturingEventPrevented = function(e){
		if(!e._isPolyfilled){
			var isDefaultPrevented = e.isDefaultPrevented;
			var preventDefault = e.preventDefault;
			e.preventDefault = function(){
				clearTimeout($.data(e.target, e.type + 'DefaultPrevented'));
				$.data(e.target, e.type + 'DefaultPrevented', setTimeout(function(){
					$.removeData(e.target, e.type + 'DefaultPrevented');
				}, 30));
				return preventDefault.apply(this, arguments);
			};
			e.isDefaultPrevented = function(){
				return !!(isDefaultPrevented.apply(this, arguments) || $.data(e.target, e.type + 'DefaultPrevented') || false);
			};
			e._isPolyfilled = true;
		}
	};
	
	if(!Modernizr.formvalidation || bugs.bustedValidity){
		testRequiredFind();
	} else {
		//create delegatable events
		webshims.capturingEvents(['input']);
		webshims.capturingEvents(['invalid'], true);
		
		if(window.opera || window.testGoodWithFix){
			
			form.appendTo('head');
			
			testRequiredFind();
			bugs.validationMessage = !(inputElem.prop('validationMessage'));
			
			webshims.reTest(['form-native-extend', 'form-message']);
			
			form.remove();
				
			$(function(){
				onDomextend(function(){
					
					//Opera shows native validation bubbles in case of input.checkValidity()
					// Opera 11.6/12 hasn't fixed this issue right, it's buggy
					var preventDefault = function(e){
						e.preventDefault();
					};
					
					['form', 'input', 'textarea', 'select'].forEach(function(name){
						var desc = webshims.defineNodeNameProperty(name, 'checkValidity', {
							prop: {
								value: function(){
									if (!webshims.fromSubmit) {
										$(this).on('invalid.checkvalidity', preventDefault);
									}
									
									webshims.fromCheckValidity = true;
									var ret = desc.prop._supvalue.apply(this, arguments);
									if (!webshims.fromSubmit) {
										$(this).unbind('invalid.checkvalidity', preventDefault);
									}
									webshims.fromCheckValidity = false;
									return ret;
								}
							}
						});
					});
					
				});
			});
		}
		
		if(isWebkit && !webshims.bugs.bustedValidity){
			(function(){
				var elems = /^(?:textarea|input)$/i;
				var form = false;
				
				document.addEventListener('contextmenu', function(e){
					if(elems.test( e.target.nodeName || '') && (form = e.target.form)){
						setTimeout(function(){
							form = false;
						}, 1);
					}
				}, false);
				
				$(window).on('invalid', function(e){
					if(e.originalEvent && form && form == e.target.form){
						e.wrongWebkitInvalid = true;
						e.stopImmediatePropagation();
					}
				});
				
			})();
		}
	}

	$.webshims.register('form-core', function($, webshims, window, document, undefined, options){
	
		var checkTypes = {checkbox: 1, radio: 1};
		var emptyJ = $([]);
		var bugs = webshims.bugs;
		var getGroupElements = function(elem){
			elem = $(elem);
			var name;
			var form;
			var ret = emptyJ;
			if(elem[0].type == 'radio'){
				form = elem.prop('form');
				name = elem[0].name;
				if(!name){
					ret = elem;
				} else if(form){
					ret = $(form[name]);
				} else {
					ret = $(document.getElementsByName(name)).filter(function(){
						return !$.prop(this, 'form');
					});
				}
				ret = ret.filter('[type="radio"]');
			}
			return ret;
		};
		
		var getContentValidationMessage = webshims.getContentValidationMessage = function(elem, validity, key){
			var message = $(elem).data('errormessage') || elem.getAttribute('x-moz-errormessage') || '';
			if(key && message[key]){
				message = message[key];
			}
			if(typeof message == 'object'){
				validity = validity || $.prop(elem, 'validity') || {valid: 1};
				if(!validity.valid){
					$.each(validity, function(name, prop){
						if(prop && name != 'valid' && message[name]){
							message = message[name];
							return false;
						}
					});
				}
			}
			
			if(typeof message == 'object'){
				message = message.defaultMessage;
			}
			return message || '';
		};
		
		/*
		 * Selectors for all browsers
		 */
		var rangeTypes = {number: 1, range: 1, date: 1/*, time: 1, 'datetime-local': 1, datetime: 1, month: 1, week: 1*/};
		var hasInvalid = function(elem){
			var ret = false;
			$($.prop(elem, 'elements')).each(function(){
				ret = $(this).is(':invalid');
				if(ret){
					return false;
				}
			});
			return ret;
		};
		$.extend($.expr[":"], {
			"valid-element": function(elem){
				return $.nodeName(elem, 'form') ? !hasInvalid(elem) :!!($.prop(elem, 'willValidate') && isValid(elem));
			},
			"invalid-element": function(elem){
				return $.nodeName(elem, 'form') ? hasInvalid(elem) : !!($.prop(elem, 'willValidate') && !isValid(elem));
			},
			"required-element": function(elem){
				return !!($.prop(elem, 'willValidate') && $.prop(elem, 'required'));
			},
			"user-error": function(elem){
				return ($.prop(elem, 'willValidate') && $(elem).hasClass('user-error'));
			},
			"optional-element": function(elem){
				return !!($.prop(elem, 'willValidate') && $.prop(elem, 'required') === false);
			},
			"in-range": function(elem){
				if(!rangeTypes[$.prop(elem, 'type')] || !$.prop(elem, 'willValidate')){
					return false;
				}
				var val = $.prop(elem, 'validity');
				return !!(val && !val.rangeOverflow && !val.rangeUnderflow);
			},
			"out-of-range": function(elem){
				if(!rangeTypes[$.prop(elem, 'type')] || !$.prop(elem, 'willValidate')){
					return false;
				}
				var val = $.prop(elem, 'validity');
				return !!(val && (val.rangeOverflow || val.rangeUnderflow));
			}
			
		});
		
		['valid', 'invalid', 'required', 'optional'].forEach(function(name){
			$.expr[":"][name] = $.expr.filters[name+"-element"];
		});
		
		
		$.expr[":"].focus = function( elem ) {
			try {
				var doc = elem.ownerDocument;
				return elem === doc.activeElement && (!doc.hasFocus || doc.hasFocus());
			} catch(e){}
			return false;
		};
		
		
		var customEvents = $.event.customEvent || {};
		var isValid = function(elem){
			return ($.prop(elem, 'validity') || {valid: 1}).valid;
		};
		
		if (bugs.bustedValidity || bugs.findRequired) {
			(function(){
				var find = $.find;
				var matchesSelector = $.find.matchesSelector;
				
				var regExp = /(\:valid|\:invalid|\:optional|\:required|\:in-range|\:out-of-range)(?=[\s\[\~\.\+\>\:\#*]|$)/ig;
				var regFn = function(sel){
					return sel + '-element';
				};
				
				$.find = (function(){
					var slice = Array.prototype.slice;
					var fn = function(sel){
						var ar = arguments;
						ar = slice.call(ar, 1, ar.length);
						ar.unshift(sel.replace(regExp, regFn));
						return find.apply(this, ar);
					};
					for (var i in find) {
						if(find.hasOwnProperty(i)){
							fn[i] = find[i];
						}
					}
					return fn;
				})();
				if(!Modernizr.prefixed || Modernizr.prefixed("matchesSelector", document.documentElement)){
					$.find.matchesSelector = function(node, expr){
						expr = expr.replace(regExp, regFn);
						return matchesSelector.call(this, node, expr);
					};
				}
				
			})();
		}
		
		//ToDo needs testing
		var oldAttr = $.prop;
		var changeVals = {selectedIndex: 1, value: 1, checked: 1, disabled: 1, readonly: 1};
		$.prop = function(elem, name, val){
			var ret = oldAttr.apply(this, arguments);
			if(elem && 'form' in elem && changeVals[name] && val !== undefined && $(elem).hasClass(invalidClass)){
				if(isValid(elem)){
					$(elem).getShadowElement().removeClass(invalidClass);
					if(name == 'checked' && val) {
						getGroupElements(elem).not(elem).removeClass(invalidClass).removeAttr('aria-invalid');
					}
				}
			}
			return ret;
		};
		
		var returnValidityCause = function(validity, elem){
			var ret;
			$.each(validity, function(name, value){
				if(value){
					ret = (name == 'customError') ? $.prop(elem, 'validationMessage') : name;
					return false;
				}
			});
			return ret;
		};
		
		var isInGroup = function(name){
			var ret;
			try {
				ret = document.activeElement.name === name;
			} catch(e){}
			return ret;
		};
		/* form-ui-invalid/form-ui-valid are deprecated. use user-error/user-success instead */
		var invalidClass = 'user-error';
		var validClass = 'user-success';
		var stopChangeTypes = {
			time: 1,
			date: 1,
			month: 1,
			datetime: 1,
			week: 1,
			'datetime-local': 1
		};
		var switchValidityClass = function(e){
			var elem, timer;
			if(!e.target){return;}
			elem = $(e.target).getNativeElement()[0];
			if(elem.type == 'submit' || !$.prop(elem, 'willValidate')){return;}
			timer = $.data(elem, 'webshimsswitchvalidityclass');
			var switchClass = function(){
				if(e.type == 'focusout' && elem.type == 'radio' && isInGroup(elem.name)){return;}
				var validity = $.prop(elem, 'validity');
				var shadowElem = $(elem).getShadowElement();
				var addClass, removeClass, trigger, generaltrigger, validityCause;
				
				if(isWebkit && e.type == 'change' && !bugs.bustedValidity && stopChangeTypes[shadowElem.prop('type')] && shadowElem.is(':focus')){return;}
				
				$(elem).trigger('refreshCustomValidityRules');
				
				if(validity.valid){
					if(!shadowElem.hasClass(validClass)){
						addClass = validClass;
						removeClass = invalidClass;
						generaltrigger = 'changedvaliditystate';
						trigger = 'changedvalid';
						if(checkTypes[elem.type] && elem.checked){
							getGroupElements(elem).not(elem).removeClass(removeClass).addClass(addClass).removeAttr('aria-invalid');
						}
						$.removeData(elem, 'webshimsinvalidcause');
					}
				} else {
					validityCause = returnValidityCause(validity, elem);
					if($.data(elem, 'webshimsinvalidcause') != validityCause){
						$.data(elem, 'webshimsinvalidcause', validityCause);
						generaltrigger = 'changedvaliditystate';
					}
					if(!shadowElem.hasClass(invalidClass)){
						addClass = invalidClass;
						removeClass = validClass;
						if (checkTypes[elem.type] && !elem.checked) {
							getGroupElements(elem).not(elem).removeClass(removeClass).addClass(addClass);
						}
						trigger = 'changedinvalid';
					}
				}
				
				if(addClass){
					shadowElem.addClass(addClass).removeClass(removeClass);
					//jQuery 1.6.1 IE9 bug (doubble trigger bug)
					setTimeout(function(){
						$(elem).trigger(trigger);
					}, 0);
				}
				if(generaltrigger){
					setTimeout(function(){
						$(elem).trigger(generaltrigger);
					}, 0);
				}
				
				$.removeData(elem, 'webshimsswitchvalidityclass');
			};
			
			if(timer){
				clearTimeout(timer);
			}
			if(e.type == 'refreshvalidityui'){
				switchClass();
			} else {
				$.data(elem, 'webshimsswitchvalidityclass', setTimeout(switchClass, 9));
			}
		};
		
		$(document).on(options.validityUIEvents || 'focusout change refreshvalidityui', switchValidityClass);
		customEvents.changedvaliditystate = true;
		customEvents.refreshCustomValidityRules = true;
		customEvents.changedvalid = true;
		customEvents.changedinvalid = true;
		customEvents.refreshvalidityui = true;
		
		
		webshims.triggerInlineForm = function(elem, event){
			$(elem).trigger(event);
		};
		
		webshims.modules["form-core"].getGroupElements = getGroupElements;
		
		
		var setRoot = function(){
			webshims.scrollRoot = (isWebkit || document.compatMode == 'BackCompat') ?
				$(document.body) : 
				$(document.documentElement)
			;
		};
		setRoot();
		webshims.ready('DOM', setRoot);
		
		webshims.getRelOffset = function(posElem, relElem){
			posElem = $(posElem);
			var offset = $(relElem).offset();
			var bodyOffset;
			$.swap($(posElem)[0], {visibility: 'hidden', display: 'inline-block', left: 0, top: 0}, function(){
				bodyOffset = posElem.offset();
			});
			offset.top -= bodyOffset.top;
			offset.left -= bodyOffset.left;
			return offset;
		};
		
		webshims.wsPopover = {
			_create: function(){
				this.options =  $.extend({}, webshims.cfg.wspopover, this.options);
				this.id = webshims.wsPopover.id++;
				this.eventns = '.wsoverlay'+this.id;
				this.timers = {};
				this.element = $('<div class="ws-popover" tabindex="-1"><div class="ws-po-outerbox"><div class="ws-po-arrow"><div class="ws-po-arrowbox" /></div><div class="ws-po-box" /></div></div>');
				this.contentElement = $('.ws-po-box', this.element);
				this.lastElement = $([]);
				this.bindElement();
				
				this.element.data('wspopover', this);
				
			},
			options: {},
			content: function(html){
				this.contentElement.html(html);
			},
			bindElement: function(){
				var that = this;
				var stopBlur = function(){
					that.stopBlur = false;
				};
				this.preventBlur = function(e){
					that.stopBlur = true;
					clearTimeout(that.timers.stopBlur);
					that.timers.stopBlur = setTimeout(stopBlur, 9);
				};
				this.element.on({
					'mousedown': this.preventBlur
				});
			},
			
			isInElement: function(container, contained){
				return container == contained || $.contains(container, contained);
			},
			show: function(element){
				var e = $.Event('wspopoverbeforeshow');
				this.element.trigger(e);
				if(e.isDefaultPrevented() || this.isVisible){return;}
				this.isVisible = true;
				element = $(element || this.options.prepareFor).getNativeElement() ;
				
				var that = this;
				var visual = $(element).getShadowElement();
	
				this.clear();
				this.element.removeClass('ws-po-visible').css('display', 'none');
				
				this.prepareFor(element, visual);
				
				this.position(visual);
				that.timers.show = setTimeout(function(){
					that.element.css('display', '');
					that.timers.show = setTimeout(function(){
						that.element.addClass('ws-po-visible').trigger('wspopovershow');
					}, 9);
				}, 9);
				$(document).on('focusin'+this.eventns+' mousedown'+this.eventns, function(e){
					if(that.options.hideOnBlur && !that.stopBlur && !that.isInElement(that.lastElement[0] || document.body, e.target) && !that.isInElement(element[0] || document.body, e.target) && !that.isInElement(that.element[0], e.target)){
						that.hide();
					}
				});
				$(window).on('resize'+this.eventns + ' pospopover'+this.eventns, function(){
					clearTimeout(that.timers.repos);
					that.timers.repos = setTimeout(function(){
						that.position(visual);
					}, 900);
				});
			},
			prepareFor: function(element, visual){
				var onBlur;
				var opts = $.extend({}, this.options, $(element.prop('form') || []).data('wspopover') || {}, element.data('wspopover'));
				var that = this;
				this.lastElement = $(element).getShadowFocusElement();
				if(opts.appendTo == 'element'){
					this.element.insertAfter(element);
				} else {
					this.element.appendTo(opts.appendTo);
				}
				
				this.element.attr({
					'data-class': element.prop('className'),
					'data-id': element.prop('id')
				});
				
				this.element.css({width: opts.constrainWidth ? visual.outerWidth() : ''});
				
				if(opts.hideOnBlur){
					onBlur = function(e){
						if(that.stopBlur){
							e.stopImmediatePropagation();
						} else {
							that.hide();
						}
					};
					
					that.timers.bindBlur = setTimeout(function(){
						that.lastElement.off(that.eventns).on('focusout'+that.eventns + ' blur'+that.eventns, onBlur);
						that.lastElement.getNativeElement().off(that.eventns);
					}, 10);
					
					
				}
				
				if(!this.prepared){
					
					if($.fn.bgIframe){
						this.element.bgIframe();
					}
				}
				this.prepared = true;
			},
			clear: function(){
				$(window).off(this.eventns);
				$(document).off(this.eventns);
				
				this.stopBlur = false;
				$.each(this.timers, function(timerName, val){
					clearTimeout(val);
				});
			},
			hide: function(){
				var e = $.Event('wspopoverbeforehide');
				this.element.trigger(e);
				if(e.isDefaultPrevented() || !this.isVisible){return;}
				this.isVisible = false;
				var that = this;
				var forceHide = function(){
					that.element.css('display', 'none').attr({'data-id': '', 'data-class': '', 'hidden': 'hidden'});
					clearTimeout(that.timers.forcehide);
				};
				this.clear();
				this.element.removeClass('ws-po-visible').trigger('wspopoverhide');
				$(window).on('resize'+this.eventns, forceHide);
				that.timers.forcehide = setTimeout(forceHide, 999);
			},
			position: function(element){
				var offset = webshims.getRelOffset(this.element.css({marginTop: 0, marginLeft: 0, marginRight: 0, marginBottom: 0}).removeAttr('hidden'), element);
				offset.top += element.outerHeight();
				this.element.css({marginTop: '', marginLeft: '', marginRight: '', marginBottom: ''}).css(offset);
			}
		};
		
		webshims.wsPopover.id = 0;
		
		/* some extra validation UI */
		webshims.validityAlert = (function(){
			
			
			var focusTimer = false;
			
			var api = webshims.objectCreate(webshims.wsPopover, {}, options.messagePopover);
			var boundHide = api.hide.bind(api);
			
			api.element.addClass('validity-alert').attr({role: 'alert'});
			$.extend(api, {
				hideDelay: 5000,
				showFor: function(elem, message, noFocusElem, noBubble){
					
					elem = $(elem).getNativeElement();
					this.clear();
					this.hide();
					if(!noBubble){
						this.getMessage(elem, message);
						
						this.show(elem);
						if(this.hideDelay){
							this.timers.delayedHide = setTimeout(boundHide, this.hideDelay);
						}
						
					}
					
					if(!noFocusElem){
						this.setFocus(elem);
					}
				},
				setFocus: function(element){
					var focusElem = $(element).getShadowFocusElement();
					var scrollTop = webshims.scrollRoot.scrollTop();
					var elemTop = focusElem.offset().top - 30;
					var smooth;
					
					if(scrollTop > elemTop){
						webshims.scrollRoot.animate(
							{scrollTop: elemTop - 5}, 
							{
								queue: false, 
								duration: Math.max( Math.min( 600, (scrollTop - elemTop) * 1.5 ), 80 )
							}
						);
						smooth = true;
					}
					try {
						focusElem[0].focus();
					} catch(e){}
					if(smooth){
						webshims.scrollRoot.scrollTop(scrollTop);
						setTimeout(function(){
							webshims.scrollRoot.scrollTop(scrollTop);
						}, 0);
					}
					
					$(window).triggerHandler('pospopover'+this.eventns);
				},
				getMessage: function(elem, message){
					if (!message) {
						message = getContentValidationMessage(elem[0]) || elem.prop('customValidationMessage') || elem.prop('validationMessage');
					}
					if (message) {
						api.contentElement.text(message);
					} else {
						this.hide();
					}
				}
			});
			
			
			return api;
		})();
		
		
		/* extension, but also used to fix native implementation workaround/bugfixes */
		(function(){
			var firstEvent,
				invalids = [],
				stopSubmitTimer,
				form
			;
			
			$(document).on('invalid', function(e){
				if(e.wrongWebkitInvalid){return;}
				var jElm = $(e.target);
				var shadowElem = jElm.getShadowElement();
				if(!shadowElem.hasClass(invalidClass)){
					shadowElem.addClass(invalidClass).removeClass(validClass);
					setTimeout(function(){
						$(e.target).trigger('changedinvalid').trigger('changedvaliditystate');
					}, 0);
				}
				
				if(!firstEvent){
					//trigger firstinvalid
					firstEvent = $.Event('firstinvalid');
					firstEvent.isInvalidUIPrevented = e.isDefaultPrevented;
					var firstSystemInvalid = $.Event('firstinvalidsystem');
					$(document).triggerHandler(firstSystemInvalid, {element: e.target, form: e.target.form, isInvalidUIPrevented: e.isDefaultPrevented});
					jElm.trigger(firstEvent);
				}
	
				//if firstinvalid was prevented all invalids will be also prevented
				if( firstEvent && firstEvent.isDefaultPrevented() ){
					e.preventDefault();
				}
				invalids.push(e.target);
				e.extraData = 'fix'; 
				clearTimeout(stopSubmitTimer);
				stopSubmitTimer = setTimeout(function(){
					var lastEvent = {type: 'lastinvalid', cancelable: false, invalidlist: $(invalids)};
					//reset firstinvalid
					firstEvent = false;
					invalids = [];
					$(e.target).trigger(lastEvent, lastEvent);
				}, 9);
				jElm = null;
				shadowElem = null;
			});
		})();
		
		$.fn.getErrorMessage = function(){
			var message = '';
			var elem = this[0];
			if(elem){
				message = getContentValidationMessage(elem) || $.prop(elem, 'customValidationMessage') || $.prop(elem, 'validationMessage');
			}
			return message;
		};
		
		if(options.replaceValidationUI){
			if(options.overrideMessages && (options.customMessages || options.customMessages == null)){
				options.customMessages = true;
				options.overrideMessages = false;
				webshims.info("set overrideMessages to false. Use customMessages instead");
			}
			webshims.ready('DOM forms', function(){
				$(document).on('firstinvalid', function(e){
					if(!e.isInvalidUIPrevented()){
						e.preventDefault();
						$.webshims.validityAlert.showFor( e.target ); 
					}
				});
			});
		}
	});

})(jQuery);
jQuery.webshims.register('form-message', function($, webshims, window, document, undefined, options){
	"use strict";
	var validityMessages = webshims.validityMessages;
	
	var implementProperties = (options.overrideMessages || options.customMessages) ? ['customValidationMessage'] : [];
	
	validityMessages.en = $.extend(true, {
		typeMismatch: {
			defaultMessage: 'Please enter a valid value.',
			email: 'Please enter an email address.',
			url: 'Please enter a URL.',
			number: 'Please enter a number.',
			date: 'Please enter a date.',
			time: 'Please enter a time.',
			range: 'Invalid input.',
			month: 'Please enter a valid value.',
			"datetime-local": 'Please enter a datetime.'
		},
		rangeUnderflow: {
			defaultMessage: 'Value must be greater than or equal to {%min}.'
		},
		rangeOverflow: {
			defaultMessage: 'Value must be less than or equal to {%max}.'
		},
		stepMismatch: 'Invalid input.',
		tooLong: 'Please enter at most {%maxlength} character(s). You entered {%valueLen}.',
		patternMismatch: 'Invalid input. {%title}',
		valueMissing: {
			defaultMessage: 'Please fill out this field.',
			checkbox: 'Please check this box if you want to proceed.'
		}
	}, (validityMessages.en || validityMessages['en-US'] || {}));
	
	if(typeof validityMessages['en'].valueMissing == 'object'){
		['select', 'radio'].forEach(function(type){
			validityMessages.en.valueMissing[type] = 'Please select an option.';
		});
	}
	if(typeof validityMessages.en.rangeUnderflow == 'object'){
		['date', 'time', 'datetime-local', 'month'].forEach(function(type){
			validityMessages.en.rangeUnderflow[type] = 'Value must be at or after {%min}.';
		});
	}
	if(typeof validityMessages.en.rangeOverflow == 'object'){
		['date', 'time', 'datetime-local', 'month'].forEach(function(type){
			validityMessages.en.rangeOverflow[type] = 'Value must be at or before {%max}.';
		});
	}
	
	validityMessages['en-US'] = validityMessages['en-US'] || validityMessages.en;
	validityMessages[''] = validityMessages[''] || validityMessages['en-US'];
	
	validityMessages.de = $.extend(true, {
		typeMismatch: {
			defaultMessage: '{%value} ist in diesem Feld nicht zulässig.',
			email: '{%value} ist keine gültige E-Mail-Adresse.',
			url: '{%value} ist kein(e) gültige(r) Webadresse/Pfad.',
			number: '{%value} ist keine Nummer.',
			date: '{%value} ist kein Datum.',
			time: '{%value} ist keine Uhrzeit.',
			month: '{%value} ist in diesem Feld nicht zulässig.',
			range: '{%value} ist keine Nummer.',
			"datetime-local": '{%value} ist kein Datum-Uhrzeit Format.'
		},
		rangeUnderflow: {
			defaultMessage: '{%value} ist zu niedrig. {%min} ist der unterste Wert, den Sie benutzen können.'
		},
		rangeOverflow: {
			defaultMessage: '{%value} ist zu hoch. {%max} ist der oberste Wert, den Sie benutzen können.'
		},
		stepMismatch: 'Der Wert {%value} ist in diesem Feld nicht zulässig. Hier sind nur bestimmte Werte zulässig. {%title}',
		tooLong: 'Der eingegebene Text ist zu lang! Sie haben {%valueLen} Zeichen eingegeben, dabei sind {%maxlength} das Maximum.',
		patternMismatch: '{%value} hat für dieses Eingabefeld ein falsches Format. {%title}',
		valueMissing: {
			defaultMessage: 'Bitte geben Sie einen Wert ein.',
			checkbox: 'Bitte aktivieren Sie das Kästchen.'
		}
	}, (validityMessages.de || {}));
	
	if(typeof validityMessages.de.valueMissing == 'object'){
		['select', 'radio'].forEach(function(type){
			validityMessages.de.valueMissing[type] = 'Bitte wählen Sie eine Option aus.';
		});
	}
	if(typeof validityMessages.de.rangeUnderflow == 'object'){
		['date', 'time', 'datetime-local', 'month'].forEach(function(type){
			validityMessages.de.rangeUnderflow[type] = '{%value} ist zu früh. {%min} ist die früheste Zeit, die Sie benutzen können.';
		});
	}
	if(typeof validityMessages.de.rangeOverflow == 'object'){
		['date', 'time', 'datetime-local', 'month'].forEach(function(type){
			validityMessages.de.rangeOverflow[type] = '{%value} ist zu spät. {%max} ist die späteste Zeit, die Sie benutzen können.';
		});
	}
	
	var currentValidationMessage =  validityMessages[''];
	var getMessageFromObj = function(message, elem){
		if(message && typeof message !== 'string'){
			message = message[ $.prop(elem, 'type') ] || message[ (elem.nodeName || '').toLowerCase() ] || message[ 'defaultMessage' ];
		}
		return message || '';
	};
	var valueVals = {
		value: 1,
		min: 1,
		max: 1
	};
	
	webshims.createValidationMessage = function(elem, name){
		var spinner;
		var message = getMessageFromObj(currentValidationMessage[name], elem);
		
		if(!message){
			message = getMessageFromObj(validityMessages[''][name], elem) || 'invalid value';
			webshims.info('could not find errormessage for: '+ name +' / '+ $.prop(elem, 'type') +'. in language: '+$.webshims.activeLang());
		}
		if(message){
			['value', 'min', 'max', 'title', 'maxlength', 'label'].forEach(function(attr){
				if(message.indexOf('{%'+attr) === -1){return;}
				var val = ((attr == 'label') ? $.trim($('label[for="'+ elem.id +'"]', elem.form).text()).replace(/\*$|:$/, '') : $.prop(elem, attr)) || '';
				if(name == 'patternMismatch' && attr == 'title' && !val){
					webshims.error('no title for patternMismatch provided. Always add a title attribute.');
				}
				if(valueVals[attr]){
					if(!spinner){
						spinner = $(elem).getShadowElement().data('wsspinner');
					}
					if(spinner && spinner.formatValue){
						val = spinner.formatValue(val, false);
					}
				}
				message = message.replace('{%'+ attr +'}', val);
				if('value' == attr){
					message = message.replace('{%valueLen}', val.length);
				}
				
			});
		}
		
		return message || '';
	};
	
	
	if(webshims.bugs.validationMessage || !Modernizr.formvalidation || webshims.bugs.bustedValidity){
		implementProperties.push('validationMessage');
	}
	
	webshims.activeLang({
		langObj: validityMessages, 
		module: 'form-core', 
		callback: function(langObj){
			
			currentValidationMessage = langObj;
		}
	});
	
	implementProperties.forEach(function(messageProp){
		webshims.defineNodeNamesProperty(['fieldset', 'output', 'button'], messageProp, {
			prop: {
				value: '',
				writeable: false
			}
		});
		['input', 'select', 'textarea'].forEach(function(nodeName){
			var desc = webshims.defineNodeNameProperty(nodeName, messageProp, {
				prop: {
					get: function(){
						var elem = this;
						var message = '';
						if(!$.prop(elem, 'willValidate')){
							return message;
						}
						
						var validity = $.prop(elem, 'validity') || {valid: 1};
						
						if(validity.valid){return message;}
						message = webshims.getContentValidationMessage(elem, validity);
						
						if(message){return message;}
						
						if(validity.customError && elem.nodeName){
							message = (Modernizr.formvalidation && !webshims.bugs.bustedValidity && desc.prop._supget) ? desc.prop._supget.call(elem) : webshims.data(elem, 'customvalidationMessage');
							if(message){return message;}
						}
						$.each(validity, function(name, prop){
							if(name == 'valid' || !prop){return;}
							
							message = webshims.createValidationMessage(elem, name);
							if(message){
								return false;
							}
						});
						return message || '';
					},
					writeable: false
				}
			});
		});
		
	});
});