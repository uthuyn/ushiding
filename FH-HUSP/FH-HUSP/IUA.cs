using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//FH-HUSP UIA
public class IUA
{
    public IUA(int sequenceLength)
    {
        RLO = new int[sequenceLength];
        U = new float[sequenceLength];
        RU = new float[sequenceLength];
        NI = new int[sequenceLength];
        FIS = new int[sequenceLength];
        OI = new int[sequenceLength];
    }

    public int[] RLO { get; set; }
    public float[] U { get; set; }
    public float[] RU { get; set; }
    public int[] NI { get; set; }
    public int[] FIS { get; set; }
    public int[] OI { get; set; }
}

