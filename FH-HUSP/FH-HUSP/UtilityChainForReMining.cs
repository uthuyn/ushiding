using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UtilityChainForReMining
{

    int seqID;

    public int SeqID
    {
        get { return seqID; }
        set { seqID = value; }
    }

    float peuts;
    public float PEUTS
    {
        get { return peuts; }
        set { peuts = value; }
    }

    float maxUtility;
    public float MaxUtility
    {
        get { return maxUtility; }
        set { maxUtility = value; }
    }

    UtilityListForReMining utilityList;
    public UtilityListForReMining UtilityList
    {
        get { return utilityList; }
        set { utilityList = value; }
    }

    public UtilityChainForReMining(int seqID, float peuts, float maxUtility, UtilityListForReMining utilityList)
    {
        this.seqID = seqID;
        this.peuts = peuts;
        this.maxUtility = maxUtility;
        this.utilityList = utilityList;
    }
}
