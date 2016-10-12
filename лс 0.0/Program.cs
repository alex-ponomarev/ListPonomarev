using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListPonomarev
{
    
  
    class List
    {                       
        Element head;
        /// <summary>
        /// Текущий элемет
        /// </summary>
        public Element element;
        /// <summary>
        /// Предыдущий элемент
        /// </summary>
        public Element before;
        /// <summary>
        /// добавить элемент в конец списка  
        /// </summary>
        /// <param name="inf">значение элемента</param>
        public void AddElement(string inf) 
        {
            element = head;
            Element newEl = new Element(inf);
            if (head == null)
            {
                head = newEl;
            }            
            else
            {
                while (element.next != null)
                {
                    element = element.next.head;
                }
                element.next = new List();
                 element.next.head = newEl;

            }
        }
        /// <summary>
        /// Вставка нового элемента на заданную позицию
        /// </summary>
        /// <param name="inf">значение элемента</param>
        /// <param name="number">номер позиции</param>
        public void AddBetween(string inf, int number)       
        {                     
            before = head;
            int i = 2;
            if (number != 1)
            {
                while (i != number)
                 {
                    before = before.next.head;
                    i++;                   
                 }
                element = new Element(inf);
                element.next = new List();
                element.next.head = before.next.head;
                before.next.head = element;              
            }
            else
            { 
                element = head;
                List newEl = new List();
                newEl.head = new Element(inf);
                head = newEl.head;
                head.next = new List();
                head.next.head = element;         
            }
        }
        /// <summary>
        /// Вывод значений
        /// </summary>
        public void OutputAll()
        {
            element = head;
            if (head != null)
            {
                while (element.next != null)
                {
                    Console.WriteLine(element.OutputElement);
                    element = element.next.head;
                }
                Console.WriteLine(element.OutputElement);
            }
                
        }
        
        
        public int Count
        { get 
          {
              element = head;
              int i = 1;
              while (element.next != null)
              {
                  i++;
                  element = element.next.head;
              }
              return i;
          } 
        }
        /// <summary>
        /// удаление не последнего элемента
        /// </summary>
        /// <param name="number">номер элемета</param>
        public void Delete(int number)
        {
            element = head;
            int i;
            if (number != 1 && number != 2)
            {
                i = 1;
                while ((i + 2) != number)
                {
                    element = element.next.head;
                    i++;
                }
                head = element.next.head;
                head = element.next.head;
            }
            else
            {
                i = number;
                if (number == 1 && head.next == null) head = null;
                else
                {
                    head = element.next.head;
                    if (i == 2) head = element.next.head;
                }
            }

        }

        /// <summary>
        /// удаление последнего элемента
        /// </summary>
        public void DeleteLast()
        {
            element = head;
            while (element.next.head.next != null) element = element.next.head;

            element.next = null;
        }
        /// <summary>
        /// поиск по значению
        /// </summary>
        /// <param name="val">значение</param>
        /// <param name="a">массив из номеров подходящих элементов</param>
        public int[] Search(string val, int[] a )   
        {
            Console.WriteLine();
            int i = 1; // номер элемента
            int j = 0; // номер подходящего элемента в массиве 
            element = head;
            while (element.next != null)
            {
                if (element.inf == val) { a[j] = i; j++;}              
                element = element.next.head;
                i++;
            }
            if (element.inf == val) { a[j] = i; j++; }
            return a;
        }
        

        class Program
        {
            static void Main(string[] args)
            {               
                 List list = new List();
                ConsoleKeyInfo K;
            do
            {
                Console.Clear(); //очистка экрана перед выводом меню
                Console.WriteLine("1.Добавить элемент в конец списка");
                Console.WriteLine("2.Добавить элемент на  заданную позицию");            
                Console.WriteLine("3.Получение количества элеметов");
                Console.WriteLine("4.Удаление элемента на заданной позиции");  
                Console.WriteLine("5.Вывести значения");
                Console.WriteLine("6.Поиск по значению");
                Console.WriteLine("Esc. Выход из программы");

                K = Console.ReadKey(); //считывание кода вводимой клавиши
                switch (K.Key)
                {
                    case ConsoleKey.D1: // если нажата клавиша с цифрой 1
                        {
                            Console.WriteLine();
                            Console.WriteLine("введите значение");
                            list.AddElement(Console.ReadLine());
                            break;
                        }
                    case ConsoleKey.D5: // если нажата клавиша с цифрой 5
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            try
                            {
                                if (list.Count > 0) list.OutputAll();
                                else Console.WriteLine("элементы отсутствуют");
                            }
                            catch
                            {
                                Console.WriteLine("элементы отсутствуют");
                            }
                            break;
                        }
                    case ConsoleKey.D3:// если нажата клавиша с цифрой 3
                        {                            
                            Console.WriteLine();
                            Console.WriteLine();
                            if (list.head != null) Console.WriteLine(list.Count);
                            else Console.WriteLine("элементы отсутствуют");
                            break;
                        }
                    case ConsoleKey.D4:// если нажата клавиша с цифрой 4
                        {
                            Console.WriteLine();
                            if (list.head == null) Console.WriteLine("элементы отсутствуют");
                            else
                            {
                                Console.WriteLine("введите номер элемента");
                                int i;  // номер элемента
                                string s = Console.ReadLine();
                                if (int.TryParse(s, out i) == true && i > 0) if (list.Count > i || ((list.Count==1) && (i == 1))) list.Delete(i);
                                    else if (list.Count == i) list.DeleteLast();
                                    else Console.WriteLine("элемент с заданым номером отсутствует");
                                else Console.WriteLine("неверый ввод данных");
                            }
                            break;
                        }
                    case ConsoleKey.D2: // если нажата клавиша с цифрой 2
                        {
                            Console.WriteLine();
                            int i; // номер элемента
                            if (list.head == null) Console.WriteLine("сначала введите хотя бы один элемент");
                            else
                            {
                                Console.WriteLine("введите номер");
                                string s = Console.ReadLine();
                                //Console.WriteLine("введите значение");
                                if (int.TryParse(s, out i) == true && i > 0)
                                    if (list.Count >= i) { Console.WriteLine("введите значение"); list.AddBetween(Console.ReadLine(), i); }
                                    else Console.WriteLine("Пожалуйста, перейдите в пункт 'Добавить элемент в конец списка' ");
                                else Console.WriteLine("неверый ввод данных");
                            }
                            break;
                        }
                    case ConsoleKey.D6: // если нажата клавиша с цифрой 6  
                        {
                            Console.WriteLine();
                           // Console.WriteLine();
                            int i = 0;
                            int j = 0;                          
                            try
                            {
                                int[] a = new int[list.Count + 1];
                                Console.WriteLine("введите значение");
                                a = list.Search(Console.ReadLine(), a);
                                if (a[0] == 0) Console.WriteLine("значение не найдено");
                                Console.WriteLine();
                                while (a[i] != 0)
                                {
                                    Console.WriteLine(a[i]);
                                    i++;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("введите хотя бы 1 элемент");
                            }
                            break;
                        }
                    default: break;
                }
                // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                System.Threading.Thread.Sleep(2000); // 2 сек.
            }
            while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc
        }

      
        }
      
    }
    
}
