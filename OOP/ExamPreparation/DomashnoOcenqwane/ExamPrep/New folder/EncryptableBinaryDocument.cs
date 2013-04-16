using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class EncryptableBinaryDocument : BinaryDocument, IEncryptable
    {
        private bool isEncrypted;

        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
        }

        public EncryptableBinaryDocument(string name, string content=null, string size=null)
            :base(name, content, size)
        {
        }

        public void Encrypt()
        {
            this.isEncrypted = true;
        }

        public void Decrypt()
        {
            this.isEncrypted = false;
        }

        public override string ToString()
        {
            if (this.isEncrypted)
            {
                return String.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }

