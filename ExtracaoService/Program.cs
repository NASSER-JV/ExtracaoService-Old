using System;
using ExtracaoService.Data;

namespace ExtracaoService
{
    class Program
    {
        static void Main(string[] args)
        {
            var operational = new Operational();
            operational.ObtainData();
        }
    }
}