using TestProject;

int mode = PrintMenu();
while(mode != 0){

    switch(mode){

        case 1:

            await new LockExample().Execute();

        break;

        case 2:

            await new MutexExample().Execute();

        break;

        case 3:

            await new TaskExample().Execute();

        break;

    }

    Console.Write("Для продолжение нажмите на любую кнопку...");
    Console.ReadKey();
    mode = PrintMenu();

}

int PrintMenu(){

    string? str;
    int value;

    do{

        Console.Clear();
        Console.Write("Способы синхронизации:\n" +
            "0. Выйти\n" +
            "1. Lock\n" +
            "2. Mutex\n" +
            "3. Task\n" +
            "Выберите пункт: ");

        str = Console.ReadLine();

    }while(!int.TryParse(str, out value));

    return value;

}