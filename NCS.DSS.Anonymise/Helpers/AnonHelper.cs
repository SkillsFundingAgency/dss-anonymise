using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.Helpers
{
    public class AnonHelper
    {

        public static string[] Forenames = {"Malia", "Tomasa", "Lyndon", "Debbie", "Ebonie", "Kristle", "Barney", "Darrick", "Dorthy", "Hertha", "Issac", "Jaimee", "Dawne", "Terica", "Maurita", "Corine", "Louie", "Isiah", "Delsie", "Genie", "Cassy", "Fanny", "Heike", "Nina", "Kira", "Aiko", "Alesha", "Emery", "Latesha", "Mamie", "Holley", "Karisa", "Roxana", "Oretha", "Karri", "Suzi", "Dave", "Oralia", "Sharee", "Camilla", "Quentin", "Shantell", "Ronald", "Leonor", "Yong", "Josue", "Nadine", "Carmine", "Lynetta", "Opal", "Yee", "Tiana", "Junko", "Berniece", "Jeremiah", "Leena", "Bernadette",
            "uann", "Kera", "Arthur", "Gretchen", "Aurore", "Lowell", "Reva", "Angelo", "Jess", "Callie", "Georgette", "Odessa", "Ricky", "Penny", "Dale", "Maribeth", "Blanch", "Dean", "Wilson", "Andrea", "Geraldine", "Adeline", "Kathrin", "Venetta", "Lila", "Donnette", "Honey", "Maxwell", "Erna", "Carolynn", "Jarred", "Prudence", "Sima", "Brice", "Dovie", "Vaughn", "Anitra", "Lesa", "Rhonda", "Jena", "Danyel", "Loma", "Winnie", "Neoma", "Millicent", "Willa", "Diane", "Zackary", "Theodore", "Song", "Demarcus", "Candida", "Carline", "Shaniqua", "Irma", "Yee", "Kanisha", "Mikel", "Lorelei",
            "Maureen", "Mariano", "Genevieve", "Shelton", "Tyron", "Tyesha", "Eleanor", "Jill", "Tifany", "Hellen", "Jenny", "Carmel", "Lyndon", "Janie", "Janyce", "Sierra", "Sharita", "Terrie", "Daniella", "Christian", "Dena", "Isabelle", "Carmelina", "Bennett", "Camilla", "Madalyn", "Carin", "Merna", "Cindy", "Shandra", "Thi", "Shala", "Nickolas", "Lidia", "Louella", "Cristina", "Marlys", "Treva", "Jerrod", "Waltraud", "Domenic", "Michell", "Ronda", "Denny", "Mi", "Rosann", "Ruben", "Beckie", "Gwyn", "Ashley", "Tish", "Carli", "Shanell", "Lakeshia", "Edith", "Darin", "Shaneka", "Sharon",
            "Nelson", "Kaila", "Alfonzo", "Florene", "Rowena", "Lawrence", "Shayna", "Tobias", "Maribeth", "Rusty", "Jammie", "Arden", "Paulita", "Mauro", "Shelia", "Tiffiny", "Pauline", "Tyron", "Shaquita", "Tiera", "Rozanne", "Shizue", "Buford", "Beulah", "Piedad", "Abel" ,
            "Aaron", "abby", "Abednego", "abigail", "Abner", "Absalom", "Adaline", "ade", "Adelaide", "Adele", "ADO", "Adolphus", "Agatha", "agnes", "Alan", "alastair", "Alberta", "aldrich", "alex", "alexandria", "alfonse", "alfy", "algy", "alicia", "alison", "Allen", "Allisandra", "Almena", "Alonzo", "ALPHUS", "Alzada", "amanda", "AMOS", "ana", "anderson", "Andrew", "angel", "Angelina", "ANGIE", "anne", "annie", "Anselm", "ANTOINETTE", "Appie", "appy", "Ara", "ARAMINTA", "Archie", "arie", "Arilla", "arlene", "armanda", "Armilda", "arminta", "ARNOLD", "artelepsa", "Arthur", "Asa", "ASAPH",
            "Athy", "AUDREY", "augustina", "Augustus", "AURILLA", "AZARIAH", "Bab", "Barbery", "barby", "BART", "Bartholomew", "Bat", "BEA", "Becca", "BEDA", "bedney", "Belinda", "bella", "benedict", "BENJY", "Berney", "Berry", "Bertha", "BESS", "Beth", "Betty", "beverly", "biddie", "Bige", "billy", "Blanche", "BOB", "boetius", "bradford", "bree", "brian", "bridgit", "Brina", "Broderick", "brose", "Bryant", "cage", "caldonia", "Calista", "Calliedona", "Calvin", "cameron", "Campbell", "Candy", "CARLOTTA", "Carmellia", "Carol", "caroline", "Carrie", "casper", "CASSANDRA", "catherine", "cathy",
            "Ced", "Celia", "CENE", "char", "Charles", "CHARM", "CHAUNCEY", "Chesley", "Chet", "Chloe", "Christa", "christiana", "Christopher", "CHUCK", "Cille", "cinderlla", "cissy", "CLAES", "Claire", "Clarence", "Clarissa", "Cleat", "clem", "cliff", "Clifton", "COCO", "COLIE", "con", "conrad", "CORA", "COREY", "cornelia", "Corny", "COURT", "Creasey", "Crys", "curg", "Cy", "Cyphorus", "Dacey", "DAISY", "DAN", "DANIEL", "Daph", "DAPHNE", "Darlene", "Davey", "Day", "Deb", "Debby", "Debra", "Deedee", "delbert", "Delia", "Delius", "della", "delores", "DELPHIA", "demaris", "Denise", "Dennison",
            "deuteronomy", "DIAH", "diane", "Dick", "DICKON", "Dicy", "Dilly", "DITUS", "dobbin", "dolph", "Domenic", "Don", "donny", "Dora", "Doris", "dorothy", "Dosie", "dot", "Doug", "dre", "Drew", "DUNCAN", "DUTCH", "Dyche", "Earnest", "EBEN", "Ed", "Edgar", "edith", "edmund", "Eduardo", "Edwin", "Edyth", "EFFIE", "Eighta", "elaine", "Eleanor", "Elena", "ELI", "Eliphalel", "elisa", "Elizabeth", "Ellen", "ellswood", "Elminie", "ELOISE", "ELSEY", "elswood", "ELWOOD", "Elze", "Emeline", "Emily", "emmy", "eph", "EPSEY", "eric", "ERIN", "Ernestine", "ERWIN", "Essa", "Essy", "ESTHER", "Etty",
            "Eudoris", "Eunice", "Eurydice", "EVA", "evan", "Evelina", "exie", "EZEKIEL", "Ezra", "FATE", "fel", "felicia", "Feltie", "Ferbie", "Ferdinando", "Fie", "Fina", "flo", "Flossy", "Ford", "frances", "Francis", "Frankie", "FRANKY", "franniey", "Freddie", "Frederica", "Frieda", "frona", "frony", "Gabriel", "Gabrielle", "Gay", "gene", "Geoffrey", "Georgia", "Geraldine", "GERRIE", "Gert", "Gil", "gina", "GLORIA", "Governor", "Greenberry", "Gregory", "gretta", "Grissel", "Gus", "gwen", "Hal", "Hamilton", "hannah", "Harold", "harry", "Hassie", "Heather", "Helen", "Heloise", "HENRY", "Herb",
            "Herman", "hessy", "hetty", "hiel", "Hiram", "HOB", "Hodge", "Hody", "Honora", "Hopkins", "horry", "hosea", "Howard", "hub", "Hugh", "ian", "Iggy", "ike", "Ina", "Indy", "Iona", "Irvin", "Irwin", "Isabel", "Isadora", "Isidore", "ivan", "IZZY", "JACKIE", "jacob", "jahoda", "JAMES", "Jan", "janice", "JANNETT", "Jay", "jean", "Jeannie", "jebadiah", "JEDIDIAH", "jefferey", "JEFFREY", "Jem", "Jennet", "Jenny", "jeremiah", "jess", "JESSIE", "Jim", "Jimmy", "jinsy", "JOANN", "joanne", "joe", "JOHANNA", "john", "jon", "Jos", "Josephine", "Josey", "josiah", "joy", "JUANITA", "Juda", "Juder",
            "Judie", "JUDY", "Julia", "Julias", "Junie", "JUNIUS", "Justus", "KAREN", "KASEY", "Kate", "Katherine", "Kathryn", "Katy", "Kayla", "Kendall", "Kenj", "kenna", "kent", "Keziah", "killis", "Kimberley", "King", "kissy", "Kittie", "Kris", "KRISTEN", "Kristopher", "L.B.", "laffie", "Lamont", "LANNA", "Laodicia", "Laura", "Laurie", "lauryn", "Lavina", "lavonia", "Lazar", "Leafa", "Lecurgus", "Left", "Lemuel", "Lenny", "leo", "Leonidas", "leonore", "Leslie", "Lester", "Lettice", "Levi", "Levone", "Lexi", "Lib", "life", "Lil", "lillah", "lilly", "lina", "lindy", "Link", "Lish", "lissia", "LIVIA",
            "liza", "Lodi", "lola", "LON", "Loomie", "Lorenzo", "Lorraine", "LORRY", "LOU", "louis", "Louvinia", "Lucas", "Lucias", "lucinda", "Lucretia", "LUKE", "lunetta", "LUTHER", "Lydia", "Mabel", "Mack", "maddy", "MADGE", "madison", "magdalena", "Maggie", "maisie", "Malachi", "malinda", "Mamie", "Mandy", "Manoah", "mantha", "Marcus", "margaretta", "Margery", "margo", "Maria", "MARIAN", "MARIE", "Marion", "Marissa", "marsha", "Martin", "marty", "MARVIN", "Mathew", "Matilda", "Matthew", "matty", "Maureen", "mavery", "max", "Mc", "Meaka", "meg", "mehitabel", "melanie", "Melinda", "Mellia", "melly",
            "Melvin", "Menaalmena", "Merci", "Merv", "mervyn", "Meus", "Michael", "Mick", "MIDDIE", "MIDGE", "millicent", "Milly", "Mina", "Mindy", "minite", "Mira", "Miriam", "mitchell", "Mitty", "Mock", "Molly", "monica", "Monnie", "Monteleon", "Monty", "MORRIS", "MOSE", "MOSS", "Myra", "Myrti", "NACE", "Nadine", "Nan", "NANDO", "Naomi", "Nappy", "NATALIE", "Nathan", "natius", "ned", "nell", "NELLIE", "nelson", "NERVIE", "Nettie", "newton", "Nicey", "NICIE", "Nicodemus", "Niel", "nikki", "noel", "NOLLIE", "NORA", "norbert", "Nowell", "Obed", "OBIE", "Ode", "Odo", "oliver", "ollie", "Ona", "Onicyphorous",
            "Ophi", "Orilla", "OSAFORUM", "OSSY", "Ote", "OZZY", "Pam", "Parmelia", "Parthenia", "Pate", "PATRICIA", "Patty", "Paula", "Pauline", "Peggy", "Penelope", "PERCIVAL", "Peregrine", "Perry", "PETE", "Phelia", "PHENEY", "Pherbia", "Philadelphia", "PHILETUS", "Philipina", "PHILLY", "PINCKNEY", "PLEASANT", "POKEY", "Posthuma", "prescott", "Providence", "prudence", "Quil", "Quillie", "Rafaela", "RAMONA", "Raphael", "ray", "Raze", "rebecca", "REG", "reginald", "Rella", "Renius", "retta", "RHODA", "rhyna", "Riah", "rich", "RICHE", "ricka", "ricky", "rissa", "Rob", "robert", "Robin", "Roderick", "Roge",
            "Roland", "rolly", "Ronald", "Ronnie", "Rosa", "Rosalinda", "ROSCOE", "ROSEANN", "Rosie", "ROSS", "Roxanna", "Roxie", "RUBE", "Rudolphus", "rupert", "Russell", "Ry", "Sadie", "SALLY", "Salvador", "samantha", "SAMSON", "Samyra", "SANFORD", "Sarilla", "savannah", "Scottie", "Seb", "see", "SENE", "Sephy", "SERENE", "sha", "Sharon", "sheila", "Shelly", "Sher", "Sheryl", "Shirley", "sibbie", "sid", "sigfired", "sigismund", "Silence", "simeon", "Sina", "sis", "Smith", "SOL", "Solomon", "Sonny", "SOPHIE", "squat", "Stal", "STEPH", "stephen", "Steve", "STUART", "SUKEY", "sulie", "Sully", "susannah",
            "Suzie", "Sy", "sydney", "Sylvanus", "tabby", "Tal", "Tamzine", "tanny", "TASHA", "TAVIA", "TEDDY", "Temperance", "Tensey", "terry", "Tessa", "Thaddeus", "THANEY", "THEODORA", "Theodosius", "Theotha", "Thirza", "THOMAS", "Thys", "tick", "Tiffy", "Tillie", "tim", "tina", "TISH", "Toby", "TOMMY", "Tory", "Trannie", "Trina", "trix", "Trudy", "Uriah", "Val", "Valeri", "Vallie", "Vandalia", "Vangie", "Veda", "Vernisee", "Veronica", "Vest", "Vet", "Vicki", "vicky", "Vicy", "Vina", "Vincenzo", "Vinnie", "VINSON", "virdie", "virgy", "VON", "Vonnie", "Wally", "walter", "webb", "wen", "WILBER", "wilfred",
            "Will", "WILLIS", "WILMA", "Winfield", "winnet", "WINNY", "Winton", "woodrow", "Yeona", "Yulan", "zachariah", "zada", "Zadock", "Zeb", "Zedediah", "Zeke", "ZEPHANIAH"
        };

        public static string[] Surnames = { "Smith", "Jones", "Taylor", "Williams", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts", "Johnson", "Lewis", "Walker", "Robinson", "Wood", "Thompson", "White", "Watson", "Jackson", "Wright", "Green", "Harris", "Cooper", "King", "Lee", "Martin", "Clarke", "James", "Morgan", "Hughes", "Edwards", "Hill", "Moore", "Clark", "Harrison", "Scott", "Young", "Morris", "Hall", "Ward", "Turner", "Carter", "Phillips", "Mitchell", "Patel", "Adams", "Campbell", "Anderson", "Allen", "Cook", "Lawson", "Day", "Woods", "Rees", "Fraser", "Black", "Fletcher", "Hussain", "Willis", "Marsh", "Ahmed", "Doyle", "Lowe",
            "Burns", "Hopkins", "Nicholson", "Parry", "Newman", "Jordan", "Henderson", "Howard", "Barrett", "Burton", "Riley", "Porter", "Byrne", "Houghton", "John", "Perry", "Baxter", "Ball", "Mccarthy", "Elliott", "Burke", "Gallagher", "Duncan", "Cooke", "Austin", "Read", "Wallace", "Hawkins", "Hayes", "Francis", "Sutton", "Davidson", "Sharp", "Holland", "Moss", "May", "Bates", "Bailey", "Parker", "Miller", "Davis", "Murphy", "Price", "Bell", "Baker", "Griffiths", "Kelly", "Simpson", "Marshall", "Collins", "Bennett", "Cox", "Richardson", "Fox", "Gray", "Rose", "Chapman", "Hunt", "Robertson", "Shaw", "Reynolds", "Lloyd", "Ellis", "Richards",
            "Russell", "Wilkinson", "Khan", "Graham", "Stewart", "Reid", "Murray", "Powell", "Palmer", "Holmes", "Rogers", "Stevens", "Walsh", "Hunter", "Thomson", "Matthews", "Ross", "Owen", "Mason", "Knight", "Kennedy", "Butler", "Saunders", "Morrison", "Bob", "Oliver", "Kemp", "Page", "Arnold", "Shah", "Stevenson", "Ford", "Potter", "Flynn", "Warren", "Kent", "Alexander", "Field", "Freeman", "Begum", "Rhodes", "O neill", "Middleton", "Payne", "Stephenson", "Pritchard", "Gregory", "Bond", "Webster", "Dunn", "Donnelly", "Lucas", "Long", "Jarvis", "Cross", "Stephens", "Reed", "Coleman", "Nicholls", "Bull", "Bartlett", "O brien", "Curtis", "Bird",
            "Patterson", "Tucker", "Bryant", "Lynch", "Mackenzie", "Ferguson", "Cameron", "Lopez", "Haynes", "Cole", "Pearce", "Dean", "Foster", "Harvey", "Hudson", "Gibson", "Mills", "Berry", "Barnes", "Pearson", "Kaur", "Booth", "Dixon", "Grant", "Gordon", "Lane", "Harper", "Ali", "Hart", "Mcdonald", "Brooks", "Ryan", "Carr", "Macdonald", "Hamilton", "Johnston", "West", "Gill", "Dawson", "Armstrong", "Gardner", "Stone", "Andrews", "Williamson", "Barker", "George", "Fisher", "Cunningham", "Watts", "Webb", "Lawrence", "Bradley", "Jenkins", "Wells", "Chambers", "Spencer", "Poole", "Atkinson", "Lawson", "Bolton", "Hardy", "Heath", "Davey", "Rice",
            "Jacobs", "Parsons", "Ashton", "Robson", "French", "Farrell", "Walton", "Gilbert", "Mcintyre", "Newton", "Norman", "Higgins", "Hodgson", "Sutherland", "Kay", "Bishop", "Burgess", "Simmons", "Hutchinson", "Moran", "Frost", "Sharma", "Slater", "Greenwood", "Kirk", "Fernandez", "Garcia", "Atkins", "Daniel", "Beattie", "Maxwell", "Todd", "Charles", "Paul", "Crawford", "O connor", "Park", "Forrest", "Love", "Rowland", "Connolly", "Sheppard", "Harding", "Banks", "Rowe",
            "Weeks", "Forde", "Millward", "Waldron", "Brookfield", "Gibb", "Eden", "Wilkie", "Hickey", "Chilvers", "Partington", "Pallett", "Manning", "London", "Karim", "Kelsey", "Knox", "Bamford", "Halliwell", "Moorhouse", "Duke", "Mack", "Hyde", "Bedford", "Nott", "Mullen", "Hodgkinson", "Locke", "Wild", "Mctaggart", "Chauhan", "Squire", "Ramsden", "Maher", "Waugh", "Shipley", "Chalmers", "Broadley", "Walls", "Algar", "Groves", "Pryor", "Valentine", "Chan", "Donovan", "Nunn", "Warburton", "Milward", "Gooding", "Marlow", "Laycock", "Glynn", "Gaffney", "Ricci", "Pollock", "Craven", "Goodall", "Downs", "Borland", "Hatton", "Rush", "Prevost", "Pond",
            "Harley", "Crabb", "Darcy", "Dobson", "Collett", "Corr", "Rothwell", "Lewin", "Crowley", "Leek", "Bowles", "Windsor", "Eales", "Lawler", "Jacob", "Sadiq", "Smallwood", "Masters", "Dougal", "Hewlett", "Darlington", "Mcavoy", "Underwood", "Drury", "Waterhouse", "Hussein", "Gorman", "Haddock", "Mathews", "Mckee", "Strachan", "Mcgrady", "Clough", "Marr", "Marks", "Riches", "Sugden", "Pickett", "Farr", "Elder", "Tuck", "Lomax", "Judd", "Wakefield", "Tang", "Foran", "Blakey", "Mistry", "Beer", "Mansfield", "Parks", "Blythe", "Rashid", "Corcoran", "Kumar", "Kinsella", "Brooker", "Peck", "Rowlinson", "Fairhurst", "Southgate", "Harry", "Bower",
            "Ricketts", "Butterworth", "Toland", "Mccall", "Swales", "Woodford", "Hoult", "Head", "Winstanley", "Emerson", "Coburn", "Rutherford", "Radford", "O dell", "Floyd", "Speed", "Featherstone", "Chappell", "Polson", "Spicer", "Crosby", "Lilley", "Worrall", "Toms", "Prescott", "Lunt", "Lester", "Phelan", "Montague", "Egan", "Fallows", "Rainey", "Steward", "Hurrell", "Hitchcock", "Aitchison", "Beatty", "Dick", "Clifton", "Forshaw", "Mcbain", "Walkden", "Machin", "Burge", "Boon", "Howes", "Makin", "Patton", "Maynard", "Tovey", "Deane", "Reading", "Wheeldon", "Warden", "Exley", "Stock", "Jobson", "Fell", "Mccullough", "Foulkes", "Milligan",
            "Heather", "Tipping", "Hamnett", "Mcdonagh", "Mcshane", "Moroney", "Keeley", "Brelsford", "Dack", "Whalley", "Inman", "Odonnell", "Street", "Alves", "Wraight", "Fitton", "Eadie", "Thom", "Rutter", "Deakin", "Tobin", "Farrar", "Gascoyne", "Shand", "Mccourt", "Coward", "Leggett", "Graves", "Fairlie", "Redding", "Rafferty", "Mcgee", "Magee", "Mallinson", "Mears", "Davenport", "O connell", "Harker", "Tweddle", "Showell", "Millett", "Stedman", "Worth", "Sturgess", "Madden", "Shea", "Sherman", "Bayliss", "Veitch", "Rowan", "Heron", "Whitham", "Alder", "Eddy", "Roscoe", "Finn", "Leal", "Edmond", "Last", "Collingwood", "Hopkinson", "Ainley",
            "Vince", "Macintyre", "Hennessy", "Llewellyn", "Parish", "Montgomery", "Haslam", "Coulter", "Gillett", "Snowden", "Burr", "Rushton", "Finlay", "Malley", "Slade", "Gaynor", "Westwood", "Brooke", "Dodds", "Prior", "Osman", "Strange", "Giblin", "Batten", "Lander", "Sayers", "Mcfadden", "Orchard", "Baron", "Benjamin", "Ritchie", "Ransom", "Heywood", "Townend", "Friend", "Ansell", "Gleave", "Boulton", "Hogan", "Fryer", "Garrett", "Moriarty", "Leith", "Court", "Hampson", "Radcliffe", "Styles", "Stringer", "Purvis", "Mortimer", "Johnstone", "Galloway", "Tolley", "Hooton", "Macarthur", "Burford", "Cheung", "Woodhouse", "Rouse", "Healey", "Hallam",
            "Steel", "Sturrock", "Abel", "Mcauley", "Bacon", "Downie", "Glass", "Ewing", "Mckie", "Oldham", "Swann", "Dubois", "Cummins", "Lunn", "Lightfoot", "Higginson", "Garrard", "Latham", "Brain", "Wale", "Aslam", "Coffey", "Luke", "Alderson", "Good", "Costa", "Compton", "Hinton", "Main", "Crook", "Keane", "Batty", "Darby", "Fischer", "Mottram", "Collard", "Biggs", "Manson", "Mathers", "Stannard", "Moffat", "Kershaw", "Isherwood", "Smythe", "Tailor", "Meakin", "Raeburn", "Swain", "Truscott", "Snow", "Cann", "Jardine", "Aston", "Longhurst", "Harman", "Gower", "Connell", "Keay", "Khalid", "Burman", "Pickard", "Sissons", "Ashworth", "Dowell", "Durham",
            "Flanagan", "Cavanagh", "Sewell", "Oates", "Creasey", "Sands", "Hine", "Cheshire", "Houston", "Michel", "Waterson", "Langton", "Sisson", "Metcalf", "Bristow", "Tyrrell", "Mcclymont", "Littlewood", "Steere", "Symonds", "Mace", "Cove", "Simms", "Myatt", "Horrocks", "Fairbairn", "Emmerson", "Cowell", "Symes", "Molyneux", "Said", "Dandy", "Bethell", "Hickman", "Turrell", "Paisley", "Kell", "Budd", "Winn", "Dawkins", "Linley", "Mcguinness", "Hawkes", "Murrell", "Doble", "Pointer", "Sharkey", "Bugg", "Hurley", "Fish", "Ashby", "Dufour", "Maddocks", "Sherry", "Hoyle", "Beadle", "Ring", "O doherty", "Garbett", "Snell", "Elliot", "Cotterill", "Cahill",
            "Bingham", "Stark", "Doran", "Tilley", "Maclean", "Allwood", "Tennant", "Caddy", "Matheson", "Carling", "Lawther", "Laird", "Oxley", "Mcginty", "Bill", "Kingston", "Lock", "Kendell", "Burdett", "Stout", "Hutchins", "Allard", "Chapple", "Mawson", "Down", "Gilmore", "Attwood", "Parmar", "Snowdon", "Mcgrory", "Laverick", "Leake", "Hanlon", "Quigley", "Wong", "Sweeting", "Mccrudden", "Alford", "Carrington", "Massey", "Burden", "Halford", "Worsnop", "Houlton", "Baines", "Lennox", "Petersen", "Donohoe", "Holdsworth", "Groom", "Bickley", "Osullivan", "Musgrove", "Avery", "Aziz", "Powers", "Thurston", "Felton", "Fagan", "Otoole", "Curley", "Gauntlett"
        };

        private static Random Rnd;
        private static char[] LettersArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static char[] ULettersArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public void SetRandomSeed(Random randSeed)
        {
            Rnd = randSeed;
        }

        public static string GetRandomForename( string source)
        {
            return Forenames[Rnd.Next(0, Forenames.GetUpperBound(0))];
        }

        public static string GetRandomSurname(string source)
        {
            return Surnames[Rnd.Next(0, Surnames.GetUpperBound(0))];
        }

        private static long LongRandom(long min, long max)
        {
            byte[] buf = new byte[8];
            Rnd.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        public static  string GetRandomNumberString(long lowerBound, long upperBound)
        {
            string returnString = "";
            try
            {
                returnString = LongRandom(lowerBound, upperBound).ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.InnerException);
            }

            return returnString;

        }

        public DateTime RandomDate()
        {
            DateTime start = new DateTime(1955, 1, 1);
            int range = (DateTime.Today - start).Days;
            DateTime returnDate = DateTime.MaxValue;
            try
            {
                returnDate = start.AddDays(Rnd.Next(range));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.InnerException);
            }
            return returnDate;
        }

        public string RandomiseText(string sourceText)
        {
            if (string.IsNullOrEmpty(sourceText))
            {
                return null;
            }
            StringBuilder returnString = new StringBuilder();
            foreach (var character in sourceText)
            {
                if (char.IsLetter(character))
                {
                    returnString.Append((char.IsUpper(character) ? ULettersArr[Rnd.Next(0, 25)] : LettersArr[Rnd.Next(0, 25)]));
                }
                else if (char.IsDigit(character))
                {
                    returnString.Append(RandomNumber());
                }
                else
                {
                    returnString.Append(character.ToString());
                }
              }
            return returnString.ToString();
        }

        public decimal RandomiseDecimal( decimal sourceDecimal)
        {
            return sourceDecimal * Convert.ToDecimal(0.5 + Rnd.NextDouble() );
        }

        public int RandomNumber()
        {
            return Rnd.Next(1, 9);

        }

        public string RandomMobile()
        {
            return "07" + RandomNumber() + RandomNumber() + RandomNumber() +
                        RandomNumber() + RandomNumber() + RandomNumber() +
                        RandomNumber() + RandomNumber();
        }

        public string RandomPhoneNumber()
        {
            StringBuilder telNo = new StringBuilder(12);
            int number;

            telNo = telNo.Append("0");
            for (int i = 0; i < 4; i++)
            {
                number = Rnd.Next(0, 8);
                telNo = telNo.Append(number.ToString());
            }
            telNo = telNo.Append(" ");
            number = Rnd.Next(0, 743);
            telNo = telNo.Append(String.Format("{0:D3}", number));
            number = Rnd.Next(0, 10000);
            telNo = telNo.Append(String.Format("{0:D4}", number));
            return telNo.ToString();
        }

        public T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(Rnd.Next(v.Length));
        }
    }
}
