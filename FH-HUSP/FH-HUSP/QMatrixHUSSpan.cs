using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class QMatrixHUSSpan
{
    int seqID;

    public int SeqID
    {
        get { return seqID; }
        set { seqID = value; }
    }
    /// <summary>
    /// the qmatrix for items  [item][itemset] -> utility </summary>
    float[][] matrixItemUtility;
    private int[][] matrixItemPos;

    public float[][] MatrixItemUtility
    {
        get { return matrixItemUtility; }
        set { matrixItemUtility = value; }
    }
    /// <summary>
    /// the qmatrix for remaining utility [item][itemset] -> remaining utility </summary>
    float[][] matrixItemRemainingUtility;

    public float[][] MatrixItemRemainingUtility
    {
        get { return matrixItemRemainingUtility; }
        set { matrixItemRemainingUtility = value; }
    }
    public int[][] MatrixItemPos
    {
        get { return matrixItemPos; }
        set { matrixItemPos = value; }
    }
    /// <summary>
    /// the item names </summary>
    int[] itemNames;

    public int[] ItemNames
    {
        get { return itemNames; }
        set { itemNames = value; }
    }
    //number of Itemset
    int nbItemsets;

    public int NbItemsets
    {
        get { return nbItemsets; }
        set { nbItemsets = value; }
    }
    /// <summary>
    /// the swu of this sequence * </summary>
    float swu;

    public float Swu
    {
        get { return swu; }
        set { swu = value; }
    }
    public IUA IUA { get; set; }

    /// <summary>
    /// Constructor </summary>
    /// <param name="nbItem"> the number of item in the sequence </param>
    /// <param name="nbItemset"> the number of itemsets in that sequence </param>
    public QMatrixHUSSpan(int nbItem, int nbItemset, int[] itemUniqeNames, int itemUniqueNamesLength,
     float swu, int sequenceLength)
    {
        matrixItemUtility = RectangularArrays.ReturnRectangularFloatArray(nbItem, nbItemset);
        matrixItemPos = RectangularArrays.ReturnRectangularIntArray(nbItem, nbItemset);
        matrixItemRemainingUtility = RectangularArrays.ReturnRectangularFloatArray(nbItem, nbItemset);
        this.swu = swu;

        this.itemNames = new int[itemUniqueNamesLength];
        Array.Copy(itemUniqeNames, 0, this.itemNames, 0, itemUniqueNamesLength);

        IUA = new IUA(sequenceLength);
    }

    /// <summary>
    /// Register item in the matrix </summary>
    /// <param name="itemPos"> an item position in "itemNames" </param>
    /// <param name="itemset"> the itemset number </param>
    /// <param name="utility"> the utility of the item in that itemset </param>
    /// <param name="remainingUtility"> the reamining utility of that item at that itemset </param>
    public virtual void registerItem(int itemPos, int itemset, float utility, float remainingUtility, int itemSeqPos, int itemName)
    {
        // we store the utility in the cell for this item/itemset
        matrixItemUtility[itemPos][itemset] = utility;
        // we store the remaining utility in the cell for this item/itemset
        matrixItemRemainingUtility[itemPos][itemset] = remainingUtility;
        matrixItemPos[itemPos][itemset] = itemSeqPos;
        IUA.U[itemSeqPos] = utility;
        IUA.RLO[itemSeqPos] = itemName;
    }


    /// <summary>
    /// Get a string representation of this matrix (for debugging purposes) </summary>
    /// <returns> the string representation </returns>
    public override string ToString()
    {
        StringBuilder buffer = new StringBuilder();
        buffer.Append(" MATRIX \n");
        for (int i = 0; i < itemNames.Length; i++)
        {
            buffer.Append("\n  item: " + itemNames[i] + "  ");
            for (int j = 0; j < matrixItemUtility[i].Length; j++)
            {
                buffer.Append("  " + matrixItemUtility[i][j] + "[" + +matrixItemRemainingUtility[i][j] + "]");
            }
        }
        buffer.Append("   swu: " + swu);
        buffer.Append("\n");
        return buffer.ToString();
    }
    public int[] getItemNames()
    {
        return this.ItemNames;
    }

    /// <summary>
    /// Get the utility of a cell in the projected q-matrix at a given cell position (row,column) </summary>
    /// <param name="row"> the row </param>
    /// <param name="column"> the column </param>
    /// <returns> the utility </returns>
    public float getItemUtility(int row, int column)
    {
        return this.MatrixItemUtility[row][column];
    }

    /// <summary>
    /// Get the remaining utility of a cell in the projected q-matrix at a given 
    /// cell position (row,column). </summary>
    /// <param name="row"> the row </param>
    /// <param name="column"> the column </param>
    /// <returns> the remaining utility </returns>
    public float getRemainingUtility(int row, int column)
    {
        return this.MatrixItemRemainingUtility[row][column];
    }
}
