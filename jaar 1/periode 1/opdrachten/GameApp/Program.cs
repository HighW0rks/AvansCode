using Tycho;

namespace GameApp
{
    class Program
    {
        public static bool inMenu = false;
        public static bool isCheckingMoney = false;
        public static bool isUpgrade = false;
        public static bool isBuyBait = false;
        public static bool isUpgradeRod = false;
        public enum Rods
        {
            basic,
            riverflow,
            trouter,
            fancyrod,
            silkline,
            aelcatcher,
            greatrod
        }

        public enum Bait
        {
            basic,
            apprentice,
            journeyman,
            expert,
            master
        }

        static void Main()
        {
            // Links up with discord bot.
            DiscordBot.Start("discord-bot-code", OnMessage);
            string OnMessage(string user, string message)
            {
                Bait bait;

                string biome = "shallow_lake";
                
                Rods rod = Rods.basic;
       
                string temp;

                List<string> inv = [];

                
                if (message.Contains("!fish"))
                {
                    string[] parts = message.Split(' ');
                    if (parts.Length < 2) return "Please provide level of bait (e.g., '1 5')";

                    switch (parts[1])
                    {
                        case "1":
                            bait = Bait.basic;
                            break;
                        
                        case "2":
                            bait = Bait.apprentice;
                            break;

                        case "3":
                            bait = Bait.journeyman;
                            break;

                        case "4":
                            bait = Bait.expert;
                            break;
                        
                        case "5":
                            bait = Bait.master;
                            break;
                        
                        default:
                            return "This is not a type of bait. Enter a number ranging from 1 - 5.";
                    }

                    if (util.CheckAccount(user, $"Bait_{parts[1]}") == 0) return "You don't have this bait. Buy it at the menu.";
                    util.UpdateAccount(user, $"Bait_{parts[1]}", util.CheckAccount(user, $"Bait_{parts[1]}") - 1);

                    temp = Fish(user, bait, biome, rod);
           
                    if (temp != "NOTHING!!!") inv.Add(temp);
                    return $"{user} has captured {temp}";
                }
                else if (message == "!menu" && !inMenu)
                {
                    return Menu(user, message);
                }
                else if (inMenu)
                {
                    return Menu(user, message);
                }
                else if (message.Contains("!travel"))
                {
                    temp = Travel(message);
                    if (temp != "?")
                    {
                        biome = temp;
                        return $"Traveling to {biome}";
                    }
                    return "invalid option.";
                }
                else if (message == "!help")
                {
                    return
                    """
                    Commands:
                    !help: Shows all commands.
                    !fish: Cast your rod.
                    !menu: Open the menu.
                    !travel: Travel to other places.
                    !thelp: Show travel locations.
                    """;
                }
                else if (message == "!thelp")
                {
                    return
                    """
                    Locations:
                    shallow lake: Calm fishing spot with lots of trouts. Good for starting your fishing adventure.
                    windy river: River with semi-strong currents. Sturdy rods that are adaptive to the rivers current are needed here, but fancier rods hold better reel. On rare occurences, glintscale fish can be found.
                    cavern lagoon: This secret lagoon is home to many extraordinary fish species. A special rod is needed to avoid your line from being snapped by the spiderfish species.
                    rocky coast: There is an abundance of trouts here, but they will rarely appear. Many other fish species live here, including the rare powerfish, but the strongest of rods and bait are required.
                    """;
                }
                else
                {
                    return "";
                }
            }
        }

        public static string Fish(string user, Bait bait, string biome, Rods rod)
        {
            switch (biome)
            {
                case "shallow_lake":
                    switch (bait)
                    {
                        case Bait.basic:
                            if (Random.Shared.Next(0, 2) == 1) 
                            {
                                util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                return "trout";
                            }
                            return "NOTHING!!!";
                         
                        case Bait.apprentice:
                            if (Random.Shared.Next(0, 5) > 0) 
                            {
                                util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                return "trout";
                            }
                            if (Random.Shared.Next(0, 3) > 0)
                            {
                                util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                return "salmon";
                            }
                            return "NOTHING!!!";
               
                        default:
                            return "NOTHING!!!";
                    }

                case "windy_river":
                    if (rod == Rods.riverflow)
                       switch (bait)
                       {
                           case Bait.basic:
                               if (Random.Shared.Next(0, 5) > 0)
                                {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                                }
                               return "NOTHING!!!";

                           case Bait.apprentice:
                               if (Random.Shared.Next(0, 7) > 0) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 5) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 10) == 1) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 150);
                                    return "glintscale";
                               }
                               return "NOTHING!!!";

                           case Bait.journeyman:
                               if (Random.Shared.Next(0, 4) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 3) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 9) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 150);
                                    return "glintscale";
                               }
                               return "NOTHING!!!";
                               
                           default:
                               return "NOTHING!!!";
                        }
                    if (rod == Rods.fancyrod)
                       switch (bait)
                       {
                           case Bait.basic:
                               if (Random.Shared.Next(0, 8) > 0)
                                {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                                }
                               return "NOTHING!!!";

                           case Bait.apprentice:
                               if (Random.Shared.Next(0, 5) > 0) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 4) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 8) == 1) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 150);
                                    return "glintscale";
                               }
                               return "NOTHING!!!";

                           case Bait.journeyman:
                               if (Random.Shared.Next(0, 6) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 2) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 8) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 150);
                                    return "glintscale";
                               }
                               return "NOTHING!!!";
                               
                           default:
                               return "NOTHING!!!";
                       }
                    return "NOTHING!!!";

                case "rocky_coast":
                    if (rod == Rods.trouter)
                    {
                       if (Random.Shared.Next(0, 50) == 1) 
                        {
                            util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 500);
                            return "supertrout";
                        }
                        util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                        return "trout";   
                    }
                    if (rod == Rods.aelcatcher || rod == Rods.greatrod)
                    {
                        switch (bait)
                       {
                           case Bait.journeyman:
                               if (Random.Shared.Next(0, 10) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 5) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 5) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 250);
                                    return "wrasse";
                               }
                               if (Random.Shared.Next(0, 5) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 200);
                                    return "blenny fish";
                               }
                               if (Random.Shared.Next(0, 15) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 1000);
                                    return "powerfish";
                               }
                               return "NOTHING!!!";

                            case Bait.expert:
                               if (Random.Shared.Next(0, 15) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 10) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 7) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 250);
                                    return "wrasse";
                               }
                               if (Random.Shared.Next(0, 3) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 200);
                                    return "blenny fish";
                               }
                               if (Random.Shared.Next(0, 15) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 1000);
                                    return "powerfish";
                               }
                               return "NOTHING!!!";

                            case Bait.master:
                               if (Random.Shared.Next(0, 17) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 50);
                                    return "trout";
                               }
                               if (Random.Shared.Next(0, 12) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 70);
                                    return "salmon";
                               }
                               if (Random.Shared.Next(0, 6) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 250);
                                    return "wrasse";
                               }
                               if (Random.Shared.Next(0, 2) > 0)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 200);
                                    return "blenny fish";
                               }
                               if (Random.Shared.Next(0, 15) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 1000);
                                    return "powerfish";
                               }
                               return "NOTHING!!!";
                               
                           default:
                               return "NOTHING!!!";
                       }
                    }
                    return "NOTHING!!!"; 

                case "cavern_lagoon":
                    if (rod == Rods.silkline)
                       switch (bait)
                       {
                            case Bait.journeyman:
                               if (Random.Shared.Next(0, 5) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 80);
                                    return "spiderfish";
                               }
                               if (Random.Shared.Next(0, 10) == 1) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 200);
                                    return "glistening cavefish";
                               }
                               return "NOTHING!!!";

                           case Bait.expert:
                                if (Random.Shared.Next(0, 3) == 1)
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 80);
                                    return "spiderfish";
                               }
                               if (Random.Shared.Next(0, 5) == 1) 
                               {
                                    util.UpdateAccount(user, "Money", util.CheckAccount(user, "Money") + 200);
                                    return "glistening cavefish";
                               }
                               return "NOTHING!!!";
                               
                           default:
                               return "NOTHING!!!";
                       }
                    return "NOTHING!!!";

                default:
                    return "NOTHING!!!";
            }
        }
        public static string Travel(string message)
        {
            if (message.Contains("shallow lake"))
            {
                return "shallow_lake";
            }
            if (message.Contains("windy river"))
            {
                return "windy_river";
            }
            if (message.Contains("rocky coast"))
            {
                return "rocky_coast";
            }
            if (message.Contains("cavern lagoon"))
            {
                return "cavern_lagoon";
            }
            else
            {
                 return "?";
            }
        }

        static void StopMenu()
        {
            inMenu = false;
            isUpgrade = false;
            isUpgradeRod = false;
            isBuyBait = false;
        }

        static string Menu(string user, string message)
        {
            if (message == "stop")
            {
                inMenu = false;
                isUpgrade = false;
                isUpgradeRod = false;
                isBuyBait = false;
                return "";
            }
            if (inMenu)
            {
                string returnMessage = "";

                if (isUpgrade)
                {
                    if (isUpgradeRod)
                    {
                        switch (message)
                        {
                            case "1":
                                StopMenu();
                                return util.BuyRod(user, 1, 100);
                            case "2":
                                StopMenu();
                                return util.BuyRod(user, 2, 300);
                            case "3":
                                StopMenu();
                                return util.BuyRod(user, 3, 1000);
                            case "4":
                                StopMenu();
                                return util.BuyRod(user, 4, 3000);
                            case "5":
                                StopMenu();
                                return util.BuyRod(user, 5, 10000);
                            case "6":
                                StopMenu();
                                return util.BuyRod(user, 6, 25000);
                            case "7":
                                StopMenu();
                                return util.BuyRod(user, 7, 100000);
                            default:
                                return "Invalid option";

                        }
                    }
                    else
                    {
                        switch (message)
                        {
                            case "1":
                                isUpgradeRod = true;
                                return $"""
                            1. Basic Rod {(util.CheckAccount(user, "Rod") == 1 ? "Owned" : "100")}
                            2. River Flow Rod {(util.CheckAccount(user, "Rod") == 2 ? "Owned" : "300")}
                            3. Trouter Rod {(util.CheckAccount(user, "Rod") == 3 ? "Owned" : "1000")}
                            4. Fancy Rod {(util.CheckAccount(user, "Rod") == 4 ? "Owned" : "3000")}
                            5. Silkline Rod {(util.CheckAccount(user, "Rod") == 5 ? "Owned" : "10000")}
                            6. Aelcatcher Rod {(util.CheckAccount(user, "Rod") == 6 ? "Owned" : "25000")}
                            7. Great Rod {(util.CheckAccount(user, "Rod") == 7 ? "Owned" : "100000")}
                            """;
                        }
                    }
                }
                else if (isBuyBait)
                {   
                    string[] parts = message.Split(' ');
                    if (parts.Length < 2) return "Please provide option and amount (e.g., '1 5')";
                    
                    string option = parts[0];
                    if (!int.TryParse(parts[1], out int amount)) return "Invalid amount format";
                    if (amount <= 0) return "Invalid amount";
                    switch (option)
                    {
                        case "1":
                            StopMenu();
                            return util.BuyBait(user, "Bait_1", amount , 5);
                        case "2":
                            StopMenu();
                            return util.BuyBait(user, "Bait_2", amount , 20);
                        case "3":
                            StopMenu();
                            return util.BuyBait(user, "Bait_3", amount , 100);
                        case "4":
                            StopMenu();
                            return util.BuyBait(user, "Bait_4", amount , 250);
                        case "5":
                            StopMenu();
                            return util.BuyBait(user, "Bait_5", amount , 500);
                        default:
                            return "Invalid option";
                    }
                }
                else
                {
                    switch (message)
                    {
                        case "1":
                            returnMessage = $"{util.CheckAccount(user, "Money")}";
                            inMenu = false;
                            break;
                        case "2":
                            isUpgrade = true;
                            returnMessage =
                            """
                            1. Upgrade Fishing Rod
                            2. TBD
                            """;
                            break;
                        case "3":
                            isBuyBait = true;
                            returnMessage =
                            $"""
                            1. Basic Bait       | Owned: {util.CheckAccount(user, "Bait_1")} | Buy: 5
                            2. Apprentice Bait  | Owned: {util.CheckAccount(user, "Bait_2")} | Buy: 20
                            3. Expert Bait      | Owned: {util.CheckAccount(user, "Bait_3")} | Buy: 100
                            4. Journeyman Bait  | Owned: {util.CheckAccount(user, "Bait_4")} | Buy: 250
                            5. Master Bait      | Owned: {util.CheckAccount(user, "Bait_5")} | Buy: 500
                            """;
                            break;
                        default:
                            return "Invalid option";
                    }
                }
                return returnMessage;
            }
            else
            {
                inMenu = true;
                return """
                1. Check money
                2. Upgrade items
                3. Buy Bait
                """;
            }
        }
    }
}