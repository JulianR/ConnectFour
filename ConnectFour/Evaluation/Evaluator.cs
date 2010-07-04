﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.Evaluation
{
  public static class Evaluator
  {

    public static int Evaluate(Game game, Player player)
    {
      var combinations = game.PlayerCombinations[player];
      var opponentCombinations = game.PlayerCombinations[(Player)1 - (int)player];

      int score = 0;

      for (int i = 0; i < combinations.Length; i++)
      {
        if (opponentCombinations[i] == 0)
        {
          switch (combinations[i])
          {
            case 1:
              score += 1;
              break;
            case 2:
              score += 10;
              break;
            case 3:
              score += 25;
              break;
          }
        }
      }

      return score;
    }

    public static bool IsLeafNode(Game game, out Player winner)
    {

      if (game.Board.InTerminalState(Player.AI))
      {
        winner = Player.AI;
        return true;
      }
      else if (game.Board.InTerminalState(Player.Human))
      {
        winner = Player.Human;
        return true;
      }

      winner = Player.None;
      return false;
    }
  }
}
