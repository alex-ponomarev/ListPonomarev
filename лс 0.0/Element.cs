using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListPonomarev
{
    class Element
    {              
        /// <summary>
        /// Значение элемента
        /// </summary>
    public string inf; 
         /// <summary>
         /// Ссылка на сл. элемент
         /// </summary>
    public List next = null;  
            public Element()
        { }
        /// <summary>
        /// добавить значение
        /// </summary>
        /// <param name="inf">значение</param>
            public Element(string inf) 
            {
                this.inf = inf;
            }
            /// <summary>
            /// выводит значение элемента
            /// </summary>
            public string OutputElement
        {
            get
            {
                return inf;
            }
        }
        
        public string NextObject
            {
            set
            {

            }
        }
    }
}