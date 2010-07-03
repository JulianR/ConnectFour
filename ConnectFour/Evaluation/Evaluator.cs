using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.Evaluation
{
  public static class Evaluator
  {
    public static int Evaluate(Game game, int depth)
    {
      var aiCombinations = game.PlayerCombinations[Player.AI];
      //var humanCombinations = game.PlayerCombinations[Player.Human];

      //int humanScore = 0;
      int aiScore = 0;

      for (int i = 0; i < 70; i++)
      {
        //int humanCombinationScore = humanCombinations[i];
        //humanScore += (humanCombinationScore * humanCombinationScore * humanCombinationScore) - (Constants.RecursionDepth - depth);

        int aiCombinationScore = aiCombinations[i];
        aiScore += (aiCombinationScore * aiCombinationScore * aiCombinationScore);// -(Constants.RecursionDepth - depth);

        /*switch (humanCombinations[i])
        {
          case 1:
            humanScore += 1;
            break;
          case 2:
            humanScore += 5;
            break;
          case 3:
            humanScore += 15;
            break;
          case 4:
            humanScore += 1000 / (Constants.RecursionDepth - depth);
            break;
        }

        switch (aiCombinations[i])
        {
          case 1:
            aiScore += 1;
            break;
          case 2:
            aiScore += 5;
            break;
          case 3:
            aiScore += 15;
            break;
          case 4:
            aiScore += 1000 / (Constants.RecursionDepth - depth);
            break;
        }*/

      }

      //return aiScore - humanScore;
      return aiScore;
    }

    public static int Evaluate(Game game, int depth, Player player)
    {
      var combinations = game.PlayerCombinations[player];

      int score = 0;

      for (int i = 0; i < combinations.Length; i++)
      {
        //int combinationScore = combinations[i];
        //score += (combinationScore * combinationScore * combinationScore) -(Constants.RecursionDepth - depth);
        switch (combinations[i])
        {
          case 1:
            score += 1;
            break;
          case 2:
            score += 5;
            break;
          case 3:
            score += 15;
            break;
        }
      }

      return score;
    }

    public static bool IsLeafNode(Game game, out Player winner)
    {
      var playerCombinations = game.PlayerCombinations[Player.Human];
      var aiCombinations = game.PlayerCombinations[Player.AI];

      for (int i = 0; i < 70; i++)
      {
        if (aiCombinations[i] == 4)
        {
          winner = Player.AI;
          return true;
        }

        if (playerCombinations[i] == 4)
        {
          winner = Player.Human;
          return true;
        }
      }

      winner = Player.None;

      return false;
    }
  }
}
