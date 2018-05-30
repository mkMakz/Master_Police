using Classes;
using Classes.Modules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Police
{
    class Program
    {
        /*А. МАСТЕР ПОЛИЦЕЙСКОЙ СТАНЦИИ
Эти вспомогательные модули предоставляют список всех Районов в области, Полицейских участков в каждом районе.
Также помогает добавлять / удалять новые районы и полицейские участки.
Необходимо создать приложение, которое будет иметь – наследование,
абстрактные кассы, свойства, авто свойства, конструкторы, методы, перегруженные методы коллекции.
Каждый справочник необходимо будет сохранить в формате Soap используя социализацию объектов.
В итоге у вас должны быт следующе справочники:
1.	Список районов
2.	Список районов (https://ru.wikipedia.org)
3.	Список служб города (101, 102, 103, 104, 105)
*/
        static void Main(string[] args)
        {

            Generate gen = new Generate();
            gen.GenerContent();
            Generate.SoapSerialize();
            Country c = Generate.SoapDeserialize();
            gen.PrintNah(c);
        }
    }
}
