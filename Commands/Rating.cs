using DuelsServer.Helpers;
using ProjectM;
using ProjectM.Network;
using Unity.Entities;
using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class Rating
    {
        [Command("r", description: "[info|createArena|removeArena|setPoint1|setPoint2] [<name>] Рейтинговая арена.", adminOnly: false)]
        public static void rating(ChatCommandContext ctx, string Arg1 = null, string Arg2 = null)
        {
            var arg1 = Arg1?.ToLower();
            var arg2 = Arg2?.ToLower();

            //Регистрация на арену
            if (arg1 == null)
            {

            }

            // Информация о рейтинге игрока
            if(arg1 == "info") 
            {

            }

            // Создание арены
            if (arg1 == "createArena")
            {
                if (arg2 == null)
                {
                    // Укажите название арены
                    return;
                }
            }

            // Удаление арены
            if (arg1 == "removeArena")
            {
                if (arg2 == null)
                {
                    // Укажите название арены
                    return;
                }
            }

            // Создание 1 точки телепорта на арену
            if (arg1 == "setPoint1")
            {
                if (arg2 == null)
                {
                    // Укажите название арены
                    return;
                }
            }

            // Создание 2 точки телепорта на арену
            if (arg1 == "setPoint2")
            {
                if (arg2 == null)
                {
                    // Укажите название арены
                    return;
                }
            }
        }
    }
}