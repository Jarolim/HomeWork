using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RoundedFigureController : FigureController
{
    public override void ExecuteFigureCreationCommand(string[] splitFigString)
    {
        switch (splitFigString[0])
        {
            case "circle":
                {
                    Vector3D a = Vector3D.Parse(splitFigString[1]);
                    double b = double.Parse(splitFigString[2]);
                    currentFigure = new Circle(a, b);
                    break;
                }
            case "cylinder":
                {
                    Vector3D a = Vector3D.Parse(splitFigString[1]);
                    Vector3D b = Vector3D.Parse(splitFigString[2]);
                    double r = double.Parse(splitFigString[3]);
                    currentFigure = new Cylinder(a, b, r);
                    break;
                }
            default:
                {
                    base.ExecuteFigureCreationCommand(splitFigString);
                    break;
                }
        }

        this.EndCommandExecuted = false;
    }

    protected override void ExecuteFigureInstanceCommand(string[] splitCommand)
    {
        switch (splitCommand[0])
        {
            case "volume":
                {
                    if (this.currentFigure is IVolumeMeasurable)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IVolumeMeasurable).GetVolume());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }
                    break;
                }
            case "area":
                {
                    if (this.currentFigure is IAreaMeasurable)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IAreaMeasurable).GetArea());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }
                    break;
                }
            case "normal":
                {
                    if (this.currentFigure is IFlat)
                    {
                        Console.WriteLine("{0:0.00}", (this.currentFigure as IFlat).GetNormal());
                    }
                    else
                    {
                        Console.WriteLine("undefined");
                    }
                    break;
                }
            default:
                {
                    base.ExecuteFigureInstanceCommand(splitCommand);
                    break;
                }
            
        }

       
    }
}

