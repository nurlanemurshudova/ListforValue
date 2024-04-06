namespace ListforValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Value value = new Value();
            ValueEdit edit = new ValueEdit();
            bool loopCheck = true;
            int count = 0;
            while (loopCheck)
            {
                Console.WriteLine("1-add integer value");
                Console.WriteLine("2-delete integer value");
                Console.WriteLine("3-show integer values");
                Console.WriteLine("4-updated the selected integer value");
                Console.WriteLine("5-quit");

                bool check = int.TryParse(Console.ReadLine(), out int number);
                if (check)
                {
                    switch (number)
                    {
                        case 1:
                            count++;
                            Console.WriteLine("Eded daxil et");
                            bool checkNum = int.TryParse(Console.ReadLine(), out int setNum);

                            if (checkNum)
                            {
                                Value value1 = new Value()
                                {
                                    MyValue = setNum,
                                    Id = count
                                };
                                edit.AddValue(value1);
                            }
                            else
                                Console.WriteLine("Integer eded daxil et");
                            break;
                        case 2:
                            Console.WriteLine("Silmek istediyin reqemin id-ni daxil et");
                            checkNum = int.TryParse(Console.ReadLine(), out int deleteNum);
                            if (checkNum)
                                edit.DeleteValue(deleteNum);
                            else
                                Console.WriteLine("Integer eded daxil et");
                            break;
                        case 3:
                            var getAllValue = edit.ShowValues();
                            foreach (var item in getAllValue)
                            {
                                Console.WriteLine($"{item.Id}. {item.MyValue}");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Deyismek istediyin ededin id-ni daxil et");
                            bool tryChangeId = int.TryParse(Console.ReadLine(), out int tryId);
                            bool tryUpdateId = false;
                            getAllValue = edit.ShowValues();
                            foreach(var item in getAllValue)
                            {
                                if( item.Id == tryId)
                                {
                                    tryUpdateId = true;
                                    break;
                                }
                            }
                            
                            if (tryUpdateId)
                            {
                                Console.WriteLine("Yeni ededi daxil et");
                                int tryValue = int.Parse(Console.ReadLine());
                    
                                Value value2 = new Value()
                                {
                                    Id = tryId,
                                    MyValue = tryValue
                                };

                                edit.UpdateValue(value2);
                            }
                            else
                            {
                                Console.WriteLine("Bele id-li istifadeci tapilmadi");
                            }
                            break;
                        case 5:
                            loopCheck = false;
                            break;
                        default:
                            Console.WriteLine("1 2 3 4 5 sec");
                            break;
                    }

                }
                else
                    Console.WriteLine("Reqem daxil et");

            }

        }
    }
    class Value
    {
        public int Id { get; set; }
        public int MyValue { get; set; }

    }
    class ValueEdit
    {
        List<Value> values = new List<Value>();
        public void AddValue(Value value)
        {
            values.Add(value);
        }
        public void DeleteValue(int i)
        {
            var deleteValue = values.Find(x => x.Id == i);
            values.Remove(deleteValue);
        }
        public List<Value> ShowValues()
        {
            return values;
        }
        public List<Value> UpdateValue(Value value)
        {
            foreach (var item in values)
            {
                if (item.Id == value.Id)
                {
                    item.MyValue = value.MyValue;
                    break;
                }
            }
            return values;
        }
    }
}
