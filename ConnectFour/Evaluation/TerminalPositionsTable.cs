using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFour.Evaluation
{
  public static class TerminalPositionsTable
  {
    private static int[][][] table;

    public static int[] Get(int column, int row)
    {
      return table[column][row];
    }

    public static void Init()
    {
      table = new int[7][][];
      for (int i = 0; i < 7; i++)
      {
        table[i] = new int[6][];
      }

      #region "Possible win-combinations"
      //c1r1
      table[0][0] = new int[3];
      table[0][0][0] = 21;
      table[0][0][1] = 27;
      table[0][0][2] = 61;
      //c2r1
      table[1][0] = new int[4];
      table[1][0][0] = 21;
      table[1][0][1] = 22;
      table[1][0][2] = 30;
      table[1][0][3] = 64;
      //c3r1
      table[2][0] = new int[5];
      table[2][0][0] = 21;
      table[2][0][1] = 22;
      table[2][0][2] = 23;
      table[2][0][3] = 33;
      table[2][0][4] = 67;
      //c4r1
      table[3][0] = new int[7];
      table[3][0][0] = 21;
      table[3][0][1] = 22;
      table[3][0][2] = 23;
      table[3][0][3] = 24;
      table[3][0][4] = 36;
      table[3][0][5] = 46;
      table[3][0][6] = 69;
      //c5r1
      table[4][0] = new int[5];
      table[4][0][0] = 22;
      table[4][0][1] = 23;
      table[4][0][2] = 24;
      table[4][0][3] = 39;
      table[4][0][4] = 48;
      //c6r1
      table[5][0] = new int[4];
      table[5][0][0] = 23;
      table[5][0][1] = 24;
      table[5][0][2] = 42;
      table[5][0][3] = 51;
      //c7r1
      table[6][0] = new int[3];
      table[6][0][0] = 24;
      table[6][0][1] = 45;
      table[6][0][2] = 54;
      //c1r2
      table[0][1] = new int[4];
      table[0][1][0] = 17;
      table[0][1][1] = 26;
      table[0][1][2] = 27;
      table[0][1][3] = 59;
      //c2r2
      table[1][1] = new int[6];
      table[1][1][0] = 17;
      table[1][1][1] = 18;
      table[1][1][2] = 29;
      table[1][1][3] = 30;
      table[1][1][4] = 61;
      table[1][1][5] = 62;
      //c3r2
      table[2][1] = new int[8];
      table[2][1][0] = 17;
      table[2][1][1] = 18;
      table[2][1][2] = 19;
      table[2][1][3] = 32;
      table[2][1][4] = 33;
      table[2][1][5] = 46;
      table[2][1][6] = 64;
      table[2][1][7] = 65;
      //c4r2
      table[3][1] = new int[10];
      table[3][1][0] = 17;
      table[3][1][1] = 18;
      table[3][1][2] = 19;
      table[3][1][3] = 20;
      table[3][1][4] = 35;
      table[3][1][5] = 36;
      table[3][1][6] = 47;
      table[3][1][7] = 48;
      table[3][1][8] = 67;
      table[3][1][9] = 68;
      //c5r2
      table[4][1] = new int[8];
      table[4][1][0] = 18;
      table[4][1][1] = 19;
      table[4][1][2] = 20;
      table[4][1][3] = 38;
      table[4][1][4] = 39;
      table[4][1][5] = 50;
      table[4][1][6] = 51;
      table[4][1][7] = 69;
      //c6r2
      table[5][1] = new int[6];
      table[5][1][0] = 19;
      table[5][1][1] = 20;
      table[5][1][2] = 41;
      table[5][1][3] = 42;
      table[5][1][4] = 53;
      table[5][1][5] = 54;
      //c7r2
      table[6][1] = new int[4];
      table[6][1][0] = 20;
      table[6][1][1] = 44;
      table[6][1][2] = 45;
      table[6][1][3] = 56;
      //c1r3
      table[0][2] = new int[5];
      table[0][2][0] = 13;
      table[0][2][1] = 25;
      table[0][2][2] = 26;
      table[0][2][3] = 27;
      table[0][2][4] = 58;
      //c2r3
      table[1][2] = new int[8];
      table[1][2][0] = 13;
      table[1][2][1] = 14;
      table[1][2][2] = 28;
      table[1][2][3] = 29;
      table[1][2][4] = 30;
      table[1][2][5] = 46;
      table[1][2][6] = 59;
      table[1][2][7] = 60;
      //c3r3
      table[2][2] = new int[11];
      table[2][2][0] = 13;
      table[2][2][1] = 14;
      table[2][2][2] = 15;
      table[2][2][3] = 31;
      table[2][2][4] = 32;
      table[2][2][5] = 33;
      table[2][2][6] = 47;
      table[2][2][7] = 48;
      table[2][2][8] = 61;
      table[2][2][9] = 62;
      table[2][2][10] = 63;
      //c4r3
      table[3][2] = new int[13];
      table[3][2][0] = 13;
      table[3][2][1] = 14;
      table[3][2][2] = 15;
      table[3][2][3] = 16;
      table[3][2][4] = 34;
      table[3][2][5] = 35;
      table[3][2][6] = 36;
      table[3][2][7] = 49;
      table[3][2][8] = 50;
      table[3][2][9] = 51;
      table[3][2][10] = 64;
      table[3][2][11] = 65;
      table[3][2][12] = 66;
      //c5r3
      table[4][2] = new int[11];
      table[4][2][0] = 14;
      table[4][2][1] = 15;
      table[4][2][2] = 16;
      table[4][2][3] = 37;
      table[4][2][4] = 38;
      table[4][2][5] = 39;
      table[4][2][6] = 52;
      table[4][2][7] = 53;
      table[4][2][8] = 54;
      table[4][2][9] = 67;
      table[4][2][10] = 68;
      //c6r3
      table[5][2] = new int[8];
      table[5][2][0] = 15;
      table[5][2][1] = 16;
      table[5][2][2] = 40;
      table[5][2][3] = 41;
      table[5][2][4] = 42;
      table[5][2][5] = 55;
      table[5][2][6] = 56;
      table[5][2][7] = 69;
      //c7r3
      table[6][2] = new int[5];
      table[6][2][0] = 16;
      table[6][2][1] = 43;
      table[6][2][2] = 44;
      table[6][2][3] = 45;
      table[6][2][4] = 57;
      //c1r4
      table[0][3] = new int[5];
      table[0][3][0] = 09;
      table[0][3][1] = 25;
      table[0][3][2] = 26;
      table[0][3][3] = 27;
      table[0][3][4] = 46;
      //c2r4
      table[1][3] = new int[8];
      table[1][3][0] = 09;
      table[1][3][1] = 10;
      table[1][3][2] = 28;
      table[1][3][3] = 29;
      table[1][3][4] = 30;
      table[1][3][5] = 47;
      table[1][3][6] = 48;
      table[1][3][7] = 58;
      //c3r4
      table[2][3] = new int[11];
      table[2][3][0] = 09;
      table[2][3][1] = 10;
      table[2][3][2] = 11;
      table[2][3][3] = 31;
      table[2][3][4] = 32;
      table[2][3][5] = 33;
      table[2][3][6] = 49;
      table[2][3][7] = 50;
      table[2][3][8] = 51;
      table[2][3][9] = 59;
      table[2][3][10] = 60;
      //c4r4
      table[3][3] = new int[13];
      table[3][3][0] = 09;
      table[3][3][1] = 10;
      table[3][3][2] = 11;
      table[3][3][3] = 12;
      table[3][3][4] = 34;
      table[3][3][5] = 35;
      table[3][3][6] = 36;
      table[3][3][7] = 52;
      table[3][3][8] = 53;
      table[3][3][9] = 54;
      table[3][3][10] = 61;
      table[3][3][11] = 62;
      table[3][3][12] = 63;
      //c5r4
      table[4][3] = new int[11];
      table[4][3][0] = 10;
      table[4][3][1] = 11;
      table[4][3][2] = 12;
      table[4][3][3] = 37;
      table[4][3][4] = 38;
      table[4][3][5] = 39;
      table[4][3][6] = 55;
      table[4][3][7] = 56;
      table[4][3][8] = 64;
      table[4][3][9] = 65;
      table[4][3][10] = 66;
      //c6r4
      table[5][3] = new int[8];
      table[5][3][0] = 11;
      table[5][3][1] = 12;
      table[5][3][2] = 40;
      table[5][3][3] = 41;
      table[5][3][4] = 42;
      table[5][3][5] = 57;
      table[5][3][6] = 67;
      table[5][3][7] = 68;
      //c7r4
      table[6][3] = new int[5];
      table[6][3][0] = 12;
      table[6][3][1] = 43;
      table[6][3][2] = 44;
      table[6][3][3] = 45;
      table[6][3][4] = 69;
      //c1r5
      table[0][4] = new int[4];
      table[0][4][0] = 05;
      table[0][4][1] = 25;
      table[0][4][2] = 26;
      table[0][4][3] = 47;
      //c2r5
      table[1][4] = new int[6];
      table[1][4][0] = 05;
      table[1][4][1] = 06;
      table[1][4][2] = 28;
      table[1][4][3] = 29;
      table[1][4][4] = 49;
      table[1][4][5] = 50;
      //c3r5
      table[2][4] = new int[8];
      table[2][4][0] = 05;
      table[2][4][1] = 06;
      table[2][4][2] = 07;
      table[2][4][3] = 31;
      table[2][4][4] = 32;
      table[2][4][5] = 52;
      table[2][4][6] = 53;
      table[2][4][7] = 58;
      //c4r5
      table[3][4] = new int[10];
      table[3][4][0] = 05;
      table[3][4][1] = 06;
      table[3][4][2] = 07;
      table[3][4][3] = 08;
      table[3][4][4] = 34;
      table[3][4][5] = 35;
      table[3][4][6] = 55;
      table[3][4][7] = 56;
      table[3][4][8] = 59;
      table[3][4][9] = 60;
      //c5r5
      table[4][4] = new int[8];
      table[4][4][0] = 06;
      table[4][4][1] = 07;
      table[4][4][2] = 08;
      table[4][4][3] = 37;
      table[4][4][4] = 38;
      table[4][4][5] = 57;
      table[4][4][6] = 62;
      table[4][4][7] = 63;
      //c6r5
      table[5][4] = new int[6];
      table[5][4][0] = 07;
      table[5][4][1] = 08;
      table[5][4][2] = 40;
      table[5][4][3] = 41;
      table[5][4][4] = 65;
      table[5][4][5] = 66;
      //c7r5
      table[6][4] = new int[4];
      table[6][4][0] = 08;
      table[6][4][1] = 43;
      table[6][4][2] = 44;
      table[6][4][3] = 68;
      //c1r6
      table[0][5] = new int[3];
      table[0][5][0] = 01;
      table[0][5][1] = 25;
      table[0][5][2] = 49;
      //c2r6
      table[1][5] = new int[4];
      table[1][5][0] = 01;
      table[1][5][1] = 02;
      table[1][5][2] = 28;
      table[1][5][3] = 52;
      //c3r6
      table[2][5] = new int[5];
      table[2][5][0] = 01;
      table[2][5][1] = 02;
      table[2][5][2] = 03;
      table[2][5][3] = 31;
      table[2][5][4] = 55;
      //c4r6
      table[3][5] = new int[7];
      table[3][5][0] = 01;
      table[3][5][1] = 02;
      table[3][5][2] = 03;
      table[3][5][3] = 04;
      table[3][5][4] = 34;
      table[3][5][5] = 57;
      table[3][5][6] = 58;
      //c5r6
      table[4][5] = new int[5];
      table[4][5][0] = 02;
      table[4][5][1] = 03;
      table[4][5][2] = 04;
      table[4][5][3] = 37;
      table[4][5][4] = 60;
      //c6r6
      table[5][5] = new int[4];
      table[5][5][0] = 03;
      table[5][5][1] = 04;
      table[5][5][2] = 40;
      table[5][5][3] = 63;
      //c7r6
      table[6][5] = new int[3];
      table[6][5][0] = 04;
      table[6][5][1] = 43;
      table[6][5][2] = 66;
      #endregion

    }


  }
}
