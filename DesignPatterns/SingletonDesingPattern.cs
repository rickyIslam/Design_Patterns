using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//SOURCE: https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/

namespace DesignPatterns
{
    // Bad code! Do not use!  
    public sealed class Singleton
    {
        //Private Constructor.  ------------------------------ 01
        private Singleton()   //------------------------------ 02
        {
        }
        private static Singleton instance = null; //---------- 03
        public static Singleton Instance // -------------------04
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
