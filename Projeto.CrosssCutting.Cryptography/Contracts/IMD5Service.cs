using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.CrosssCutting.Cryptography.Contracts
{
    public interface IMD5Service
    {
        string Encryptar(string value);
    }
}
