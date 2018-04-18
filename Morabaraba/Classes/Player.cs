﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        private int CowLives = 4;

        public Player(Symbol symbol)
        {
            this.symbol = symbol;
            millsFormed = new List<List<string>>();
            LastPosPlayed = new List<string>();
            Phase = Phase.placing;
            loses = false;
        }
        public Symbol symbol { get; set; }
        public Phase Phase { get; set; }
        public List<string> LastPosPlayed { get ; set ; }
        public List<List<string>> millsFormed { get; set; }
        public int cowLives { get => CowLives; set => CowLives = value; }
        public bool loses { get; set; }

        public List<Piece> Pieces(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
