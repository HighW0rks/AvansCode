namespace opdracht2
{
    class EnergieMeting
    {
        public class DayUsage
        {
            public int Dag { set; get; }
            public double Verbruik { set; get; }
        }
    
        // setting global variables
        public static List<DayUsage> perDagUsage = [];
        public static List<int> dagenPerMaand = [];
        public static double jaarGebruik;
        public static List<double> energyConsumed =
            [59716.69, 59733.341, 59748.377,
            59762.3, 59779.183, 59792.645,
            59805.086, 59821.529, 59836.905,
            59852.929, 59868.372, 59882.309,
            59897.09, 59914.089, 59926.973,
            59944.27, 59957.935, 59974.232,
            59990.523, 60003.33, 60020.958,
            60034.174, 60048.939, 60066.7,
            60079.869, 60094.128, 60106.724,
            60124.57, 60138.805, 60155.853,
            60169.264, 60182.74, 60196.678,
            60211.457, 60227.999, 60243.812,
            60256.65, 60270.851, 60287.041,
            60302.189, 60316.849, 60329.531,
            60346.026, 60360.144, 60377.936,
            60391.612, 60406.551, 60419.757,
            60436.143, 60452.39, 60468.558,
            60483.067, 60495.199, 60511.936,
            60527.275, 60539.978, 60555.093,
            60569.795, 60584.355, 60599.097,
            60610.941, 60621.831, 60633.382,
            60645.498, 60659.643, 60670.983,
            60682.449, 60694.115, 60705.712,
            60720.146, 60734.692, 60746.512,
            60760.828, 60772.717, 60788.086,
            60799.678, 60812.599, 60826.224,
            60839.375, 60853.324, 60866.788,
            60880.394, 60893.819, 60909.252,
            60921.439, 60932.786, 60946.693,
            60958.383, 60970.195, 60984.236,
            60999.157, 61008.156, 61019.184,
            61028.71, 61037.374, 61046.277,
            61056.662, 61068.194, 61079.398,
            61090.518, 61098.661, 61109.477,
            61119.186, 61130.305, 61139.385,
            61150.771, 61160.343, 61170.342,
            61180.637, 61189.697, 61199.445,
            61209.671, 61219.959, 61230.34,
            61239.675, 61249.726, 61259.655,
            61269.099, 61279.323, 61287.985,
            61299.008, 61305.211, 61310.483,
            61316.216, 61322.12, 61328.232,
            61333.15, 61338.877, 61345.46,
            61350.078, 61356.566, 61361.646,
            61366.56, 61372.448, 61377.966,
            61382.883, 61387.739, 61392.741,
            61398.451, 61404.871, 61410.013,
            61415.962, 61422.536, 61428.189,
            61433.775, 61438.397, 61443.239,
            61448.203, 61453.826, 61460.639,
            61465.799, 61471.693, 61473.814,
            61476.37, 61478.737, 61480.635,
            61483.252, 61485.28, 61487.663,
            61489.623, 61492.234, 61494.602,
            61497.117, 61499.534, 61502.225,
            61504.344, 61506.236, 61508.114,
            61509.911, 61511.858, 61514.5,
            61517.184, 61519.48, 61521.845,
            61524.023, 61526.064, 61528.058,
            61530.469, 61532.8, 61535.286,
            61537.577, 61539.945, 61540.131,
            61540.37, 61540.593, 61540.815,
            61541.127, 61541.344, 61541.642,
            61541.948, 61542.247, 61542.475,
            61542.698, 61542.914, 61543.16,
            61543.474, 61543.745, 61544.046,
            61544.33, 61544.626, 61544.877,
            61545.132, 61545.367, 61545.655,
            61545.923, 61546.216, 61546.433,
            61546.722, 61546.979, 61547.235,
            61547.462, 61547.753, 61548.044,
            61548.274, 61548.548, 61548.761,
            61549.055, 61549.321, 61549.55,
            61549.791, 61550.092, 61550.306,
            61550.539, 61550.841, 61551.065,
            61551.373, 61551.606, 61551.91,
            61552.22, 61552.472, 61552.69,
            61552.947, 61553.172, 61553.425,
            61553.724, 61553.953, 61554.219,
            61554.477, 61554.782, 61555.052,
            61555.313, 61555.534, 61555.822,
            61556.079, 61558.665, 61561.201,
            61563.474, 61565.551, 61568.134,
            61570.478, 61572.925, 61575.516,
            61577.342, 61579.328, 61581.221,
            61583.724, 61585.866, 61588.47,
            61590.325, 61592.586, 61594.593,
            61596.575, 61598.481, 61601.163,
            61603.551, 61605.843, 61608.438,
            61610.398, 61612.215, 61614.604,
            61616.659, 61618.917, 61620.804,
            61623.237, 61628.607, 61634.352,
            61639.196, 61645.09, 61650.523,
            61655.498, 61660.087, 61666.2,
            61671.618, 61678.171, 61683.12,
            61689.148, 61694.636, 61701.168,
            61705.719, 61710.282, 61715.369,
            61722.122, 61727.628, 61733.555,
            61739.489, 61745.539, 61751.39,
            61757.08, 61761.933, 61766.91,
            61771.884, 61778.107, 61782.813,
            61789.254, 61795.513, 61807.094,
            61816.948, 61825.655, 61834.728,
            61844.293, 61852.007, 61862.431,
            61870.202, 61878.612, 61890.219,
            61900.335, 61908.994, 61917.748,
            61926.315, 61936.877, 61945.831,
            61955.063, 61964.527, 61973.152,
            61983.603, 61993.745, 62004.134,
            62013.185, 62022.225, 62031.648,
            62039.387, 62047.686, 62058.245,
            62067.93, 62076.682, 62090.188,
            62102.141, 62114.418, 62127.175,
            62141.331, 62156.695, 62171.06,
            62184.824, 62200.171, 62214.147,
            62226.62, 62239.664, 62251.567,
            62263.772, 62276.555, 62288.949,
            62301.554, 62314.214, 62325.18,
            62339.052, 62353.094, 62364.743,
            62375.96, 62388.187, 62399.974,
            62411.269, 62421.897, 62433.216,
            62447.736, 62461.25];


        static void Main()
        {
            // Opdracht 1 Jaaroverzicht
            Opdracht1();
            Console.WriteLine();

            // Dagen per maand bepalen
            for (int maand = 1; maand <= 12; maand++)
            {
                dagenPerMaand.Add(DateTime.DaysInMonth(DateTime.Now.Year, maand));
            }

            // Variable bepalen
            List<double> energyMonth = [];
            int month = 1;
            int checkDays = dagenPerMaand[month - 1];
            double consumedDay = 0;
            double consumedMonth = 0;
            double old_value = energyConsumed[0];

            // Opdracht 2 Verbruik per maand 
            // Alle dagen opslaan en maandelijks gebruik opslaan
            for (int i = 0; i < energyConsumed.Count; i++)
            {
                double new_value = energyConsumed[i];
                if (new_value > old_value)
                {
                    consumedDay = new_value - old_value;
                    consumedMonth += consumedDay;
                    perDagUsage.Add(new DayUsage
                    {
                        Dag = i,
                        Verbruik = consumedDay
                    });
                    consumedDay = 0;
                    old_value = new_value;
                }
                // check of alle dagen in de maand verbruikt zijn en slaat ze op
                if (i == checkDays - 1)
                {
                    energyMonth.Add(consumedMonth);
                    EnhancedText($"Consumed in month {(Maanden)month}: ", ConsoleColor.Gray, false);
                    EnhancedText($"{consumedMonth:F2} ", ConsoleColor.Yellow, false);
                    EnhancedText("kWh", ConsoleColor.Gray, true);
                    consumedMonth = 0;
                    month += 1;
                    if (month <= 12)
                    {
                        checkDays += dagenPerMaand[month - 1];
                    }
                }
            }
            Console.WriteLine();
            // Opdracht 3 maandoverzicht in een nieuwe lijst
            EnhancedText($"Checken jaarGebruik vs maand gebruik (opgeteld)", ConsoleColor.DarkGray, true);
            EnhancedText("Jaar: ", ConsoleColor.DarkBlue, false);
            EnhancedText($"{jaarGebruik}", ConsoleColor.Cyan, true);
            EnhancedText("Maand: ", ConsoleColor.DarkBlue, false);
            EnhancedText($"{energyMonth.Sum()}", ConsoleColor.Cyan, true);

            if (jaarGebruik == energyMonth.Sum())
            {
                EnhancedText("Check klopt!", ConsoleColor.Green, true);
            }
            else
            {
                EnhancedText("Check klopt niet!", ConsoleColor.Red, true);
            }
            Console.WriteLine();

            // Opdracht 4 Hoe groot is het huishouden?
            Opdracht4();
            Console.WriteLine();
            UitdagingOpdracht();
            Console.WriteLine();
        }

        static void Opdracht1()
        {
            double begin = energyConsumed[0];
            double end = energyConsumed[energyConsumed.Count - 1];
            jaarGebruik = end - begin;

            EnhancedText($"De beginstand op 1 januari is: ", ConsoleColor.Gray, false);
            EnhancedText($"{begin} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);

            EnhancedText($"De eindstand op 31 december is: ", ConsoleColor.Gray, false);
            EnhancedText($"{end} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);

            EnhancedText($"Het jaarverbruik is: ", ConsoleColor.Gray, false);
            EnhancedText($"{jaarGebruik:F2} ", ConsoleColor.Yellow, false);
            EnhancedText("kWh", ConsoleColor.Gray, true);
        }

        static void Opdracht4()
        {
            string huishouden;
            
            // Let op: de grenswaarden tussen de categorieën zijn gebaseerd op de middens (gemiddelden) tussen 1-, 2-, 3- en 4-persoonshuishoudens.
            switch (jaarGebruik)
            {
                case >= 0 and < (1640 + 2550) / 2:
                    huishouden = "1";
                    break;
                case >= (1640 + 2550) / 2 and < (2550 + 3080) / 2:
                    huishouden = "2";
                    break;
                case >= (2550 + 3080) / 2 and < (3080 + 3600) / 2:
                    huishouden = "3";
                    break;
                case >= (3080 + 3600) / 2 and < (3600 + 3980):
                    huishouden = "4";
                    break;
                default:
                    huishouden = "5+";
                    break;
            }
            EnhancedText($"Op basis van het jaarverbruik behoort dit huishouden waarschijnlijk tot de categorie: {huishouden} man groot", ConsoleColor.Magenta, true);
            
        }
        static void UitdagingOpdracht()
        {
            var top3 = perDagUsage
                        .OrderByDescending(d => d.Verbruik)
                        .Take(3)
                        .ToList();
            foreach (var top in top3)
            {
                int Dag = top.Dag;
                int maand = 0;
                while (Dag > dagenPerMaand[maand])
                {
                    Dag -= dagenPerMaand[maand];
                    maand++;
                }
                maand++; // Zorgt ervoor dat Januari (1) correct word weergeven
                Console.WriteLine($"Je hebt op {Dag} {(Maanden)maand}: {top.Verbruik:F2} kWh verbruikt");
            }
        }
        static void EnhancedText(string text, ConsoleColor color, bool WriteLine)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (WriteLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
            Console.ForegroundColor = originalColor;
        }
    }
}
