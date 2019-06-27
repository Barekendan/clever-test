Задача #1
Есть "сервер" в виде статического класса.  
У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count. 

Нужно реализовать GetCount / AddToCount так, чтобы: 

    читатели могли читать параллельно, без выстраивания в очередь по локу; 
    писатели писали только последовательно и никогда одновременно; 
    пока писатели добавляют и пишут, читатели должны ждать окончания записи. 


Задача #2
В .net есть возможность звать делегаты как синхронно: 
EventHandler h = new EventHandler(this.myEventHandler); 
h.Invoke(null, EventArgs.Empty); 
так и асинхронно:
var res = h.BeginInvoke(null, EventArgs.Empty, null, null);

Нужно реализовать возможность полусинхронного вызова делегата (написать реализацию класса AsyncCaller), который бы работал таким образом: 

EventHandler h = new EventHandler(this.myEventHandler); 
ac = new AsyncCaller(h); 
bool completedOK = ac.Invoke(5000, null, EventArgs.Empty);

"Полусинхронного" в данном случае означает, что делегат будет вызван, и вызывающий поток будет ждать, пока вызов не выполнится.  Но если выполнение делегата займет больше 5000 миллисекунд, то ac.Invoke выйдет и вернет в completedOK значение false.
