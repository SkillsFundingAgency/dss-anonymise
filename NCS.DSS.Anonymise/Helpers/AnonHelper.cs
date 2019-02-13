using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCS.DSS.Anonymise.Helpers
{
    public class AnonHelper
    {
        public static string[] Forenames = {"Malia ", "Tomasa ", "Lyndon ", "Debbie ", "Ebonie ", "Kristle ", "Barney", "Darrick ", "Dorthy ", "Hertha ", "Issac ", "Jaimee ", "Dawne ", "Terica ", "Maurita ", "Corine ", "Louie ", "Isiah ", "Delsie ", "Genie ", "Cassy ", "Fanny ", "Heike ", "Nina ", "Kira ", "Aiko ", "Alesha ", "Emery ", "Latesha ", "Mamie ", "Holley ", "Karisa ", "Roxana ", "Oretha ", "Karri ", "Suzi ", "Dave ", "Oralia ", "Sharee ", "Camilla ", "Quentin ", "Shantell ", "Ronald ", "Leonor ", "Yong ", "Josue ", "Nadine ", "Carmine ", "Lynetta ", "Opal ", "Yee ", "Tiana ", "Junko ", "Berniece ", "Jeremiah ", "Leena ", "Bernadette",
            "uann ", "Kera ", "Arthur ", "Gretchen ", "Aurore ", "Lowell ", "Reva ", "Angelo ", "Jess ", "Callie ", "Georgette ", "Odessa ", "Ricky ", "Penny ", "Dale ", "Maribeth ", "Blanch ", "Dean ", "Wilson ", "Andrea ", "Geraldine ", "Adeline ", "Kathrin ", "Venetta ", "Lila ", "Donnette ", "Honey ", "Maxwell ", "Erna ", "Carolynn ", "Jarred ", "Prudence ", "Sima ", "Brice ", "Dovie ", "Vaughn ", "Anitra ", "Lesa ", "Rhonda ", "Jena ", "Danyel ", "Loma ", "Winnie ", "Neoma ", "Millicent ", "Willa ", "Diane ", "Zackary ", "Theodore ", "Song ", "Demarcus ", "Candida ", "Carline ", "Shaniqua ", "Irma ", "Yee ", "Kanisha ", "Mikel ", "Lorelei ",
            "Maureen ", "Mariano ", "Genevieve ", "Shelton ", "Tyron ", "Tyesha ", "Eleanor ", "Jill ", "Tifany ", "Hellen ", "Jenny ", "Carmel ", "Lyndon ", "Janie ", "Janyce ", "Sierra ", "Sharita ", "Terrie ", "Daniella ", "Christian ", "Dena ", "Isabelle ", "Carmelina ", "Bennett ", "Camilla ", "Madalyn ", "Carin ", "Merna ", "Cindy ", "Shandra ", "Thi ", "Shala ", "Nickolas ", "Lidia ", "Louella ", "Cristina ", "Marlys ", "Treva ", "Jerrod ", "Waltraud ", "Domenic ", "Michell ", "Ronda ", "Denny ", "Mi ", "Rosann ", "Ruben ", "Beckie ", "Gwyn ", "Ashley ", "Tish ", "Carli ", "Shanell ", "Lakeshia ", "Edith ", "Darin ", "Shaneka ", "Sharon ",
            "Nelson ", "Kaila ", "Alfonzo ", "Florene ", "Rowena ", "Lawrence ", "Shayna ", "Tobias ", "Maribeth ", "Rusty ", "Jammie ", "Arden ", "Paulita ", "Mauro ", "Shelia ", "Tiffiny ", "Pauline ", "Tyron ", "Shaquita ", "Tiera ", "Rozanne ", "Shizue ", "Buford ", "Beulah ", "Piedad ", "Abel " };

        public static string GetRandomForename( string source)
        {
            Random rnd = new Random();
            return Forenames[rnd.Next(0, Forenames.GetUpperBound(0))];
        }
    }
}
