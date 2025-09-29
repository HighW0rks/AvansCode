namespace Tycho
{
    class util
    {
        public static string[] ReadAccount(string user)
        {
            string accountPath = Path.Combine("account", $"{user}.txt");
            if (!File.Exists(accountPath))
            {
                CheckAccountExists(user);
            }
            string[] lines = File.ReadAllLines(accountPath);
            return lines;

        }

        public static void CheckAccountExists(string user)
        {
            string accountPath = Path.Combine("account", $"{user}.txt");
            if (!File.Exists(accountPath))
            {
                Directory.CreateDirectory("account");
                string defaultContent = "Money: 500\nRod: 1\nBait_1: 20\nBait_2: 0\nBait_3: 0\nBait_4: 0\nBait_5: 0";
                File.WriteAllText(accountPath, defaultContent);
            }
        }

        public static void UpdateAccount(string user, string option, int value)
        {
            string accountPath = Path.Combine("account", $"{user}.txt");

            string[] lines = ReadAccount(user);
            for (int i = 0; i < lines.Length; i++)
            {   
                if (lines[i].StartsWith($"{option}:"))
                {
                    lines[i] = $"{option}: {value}";
                    break;
                }
            }

            File.WriteAllLines(accountPath, lines);
        }

        public static int CheckAccount(string user, string option)
        {
            string[] lines = ReadAccount(user);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(option))
                {
                    if (int.TryParse(lines[i].Split(":")[1].Trim(), out int amount))
                        return amount;
                }
            }
            return 0;
        }
        public static int CheckUpgrade(string user, string type)
        {
            string[] lines = ReadAccount(user);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(type))
                {
                    if (int.TryParse(lines[i].Split(":")[1].Trim(), out int rod))
                        return rod;
                }
            }
            return 0;
        }


        public static string BuyRod(string user, int rod, int amount)
        {
            if (rod == CheckUpgrade(user, "Rod"))
            {
                return "You cant buy your owned rod";
            }
            else if (amount > CheckAccount(user, "Money"))
            {
                return "You cant purchase this rod";
            }
            else
            {
                UpdateAccount(user, "Money", CheckAccount(user, "Money") - amount);
                UpdateAccount(user, "Rod", rod);
                return "You have purchased the rod!";
            }
        }

        public static string BuyBait(string user, string bait, int amount, int cost)
        {
             if (amount * cost > CheckAccount(user, "Money"))
            {
                return "You cant purchase this bait";
            }
            else
            {
                UpdateAccount(user, "Money", CheckAccount(user, "Money") - amount * cost);
                UpdateAccount(user, bait, CheckAccount(user, bait) + amount);
                return "You have purchased the bait!";
            }
        }
    }
}