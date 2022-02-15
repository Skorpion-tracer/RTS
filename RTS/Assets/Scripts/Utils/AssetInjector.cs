using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils
{
    public static class AssetInjector
    {
        public static Type Inject<T>(this AssetsContext context, T target)
        {
            return target;
        }
    }
}
