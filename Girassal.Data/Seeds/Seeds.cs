using Girassol.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girassol.Data.Seeds
{
    public static class Seeds
    {

        public static async Task Run()
        {
            await ApplicationSeed.SeedSimpleEntity();
        }

    }
}
