using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject
{
    class Bank
    {
        public string name;
        public double balance = 0, account;

        public Bank(string names, double firstdepo, double accounts)
        {
            name = names;
            balance += firstdepo;
            account = accounts;

        }

        public double getBal()
        {
            return balance;
        }

        public string getName()
        {
            return this.name;
        }
        public double getAccount()
        {
            return account;
        }


        public void deposit(double addAmt)
        {
            balance += addAmt;
        }

        public bool withdraw(double outAmt)
        {
            bool check = true;
            if (outAmt <= balance)
            {
                balance -= outAmt;
            }
            else if (outAmt > balance)
            {
                check = false;
            }
            return check;
        }
    }
    class BankProgram2
    {
        static void Main(string[] args)
        {
            List<Bank> bank = new List<Bank>();
            double[] accNbr = new double[10];
            int ch, z = 0;

            do
            {
                Console.Write("1. Set new account\n2. Check balance\n3. Deposit amount\n4.Withdraw amount\n0.Exit\n\nSelect Function: ");
                ch = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                switch (ch)
                {
                    case 1:
                        System.Random random = new System.Random();
                        Console.Write("Enter Account Holder Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter your first initial balance: ");
                        double init = double.Parse(Console.ReadLine());

                        double account = random.Next(111111, 999999);


                        bank.Add(new Bank(name, init, account));
                        Console.WriteLine("Bank Account Added Successfully and Your account number is :" + account);
                        Console.ReadLine();
                        if (account != 0)
                        {
                            accNbr[z] = account;
                            z++;

                        }
                        break;
                    case 2:
                        Console.Write("Stored Account Numbers ");
                        Console.WriteLine();
                        Console.WriteLine("\nSRNO. \t Account Number");
                        //string namechk = Console.ReadLine();
                        for (int k = 0; k < z; k++)
                        {
                            Console.WriteLine((k + 1) + "\t" + accNbr[k]);
                        }
                        int count = 0;
                        int ind = 0;
                        Console.WriteLine("Enter Account Number for Details:");
                        double accountchk = Convert.ToDouble(Console.ReadLine());
                        for (int i = 0; i < bank.Count; i++)
                        {
                            
                            if (bank[i].account == accountchk)
                            {
                                count += 1;
                                ind = i;

                            }


                        }
                        if (count == 1)
                        {
                            Console.WriteLine("Account Found!\nName: {0}\nBalance:{1}\nA/C No:{2}", bank[ind].name, bank[ind].balance, bank[ind].account);
                        }
                        else
                        {
                            Console.WriteLine("Opp's Account not Found!");
                        }
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter Account Holder Name: ");
                        string namechk = Console.ReadLine(), nmNow = null;
                        int accNum = -1;
                        for (int i = 0; i < bank.Count; i++)
                        {
                            if (bank[i].name == namechk)
                            {
                                nmNow = namechk;
                                accNum = i;
                            }
                        }
                        if (accNum != -1)
                        {
                            Console.Write("Please Enter Amount to Deposit: ");
                            bank[accNum].deposit(double.Parse(Console.ReadLine()));
                            Console.WriteLine("Amount successfully deposited!");
                        }
                        else { Console.WriteLine("Account not found!"); }
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter Account Holder Name: ");
                        namechk = Console.ReadLine();
                        nmNow = null;
                        accNum = -1;
                        for (int i = 0; i < bank.Count; i++)
                        {
                            if (bank[i].name == namechk)
                            {
                                nmNow = namechk;
                                accNum = i;
                            }
                        }
                        if (accNum != -1)
                        {
                            Console.Write("Please Enter Amount to Withdraw: ");
                            bool ok = bank[accNum].withdraw(double.Parse(Console.ReadLine()));
                            if (ok)
                            {
                                Console.WriteLine("Amount successfully withdrawn....!");
                                if (bank[accNum].balance == 0)
                                {
                                    bank[accNum] = null;
                                    Console.WriteLine("Your Account is closed....!");
                                }
                            }
                            else { Console.WriteLine("Insufficient Balance....!"); }
                        }
                        else { Console.WriteLine("Account not found....!"); }
                        Console.ReadLine();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Please Enter Valid Syntax....!");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            } while (ch != 0);


        }
    }
}