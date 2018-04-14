using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IReferee
    {
        IPlayer Winner();
        bool IsDraw(int turns);
        void Play();

    }
}
