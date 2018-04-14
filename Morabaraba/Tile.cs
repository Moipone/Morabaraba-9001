using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Tile : ITile
    {
        public Tile(string pos, IPiece cond)
        {
            this.pos = pos;
            this.cond = cond;
           
        }

        public Tile GetTile(string pos)
        {
            Board board = new Board();
            List<Tile> BD = board.generateBoard();
            for (int i = 0; i < BD.Count; i++)
            {
                if (BD[i].pos == pos) return BD[i];
            }
            return null;
        }
        public void UpdateTile(Tile t)
        {
            Board board = new Board();
            List<Tile> BD = board.generateBoard();
            for (int i = 0; i < BD.Count; i++)
            {
                if (BD[i].pos == t.pos)
                {
                    BD.Insert(i, t);
                    BD.Remove(BD[i + 1]);
                    break;
                }
            }
        }
        public string pos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPiece cond { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
