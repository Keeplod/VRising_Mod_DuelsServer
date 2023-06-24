using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class Help
    {
        [Command("help", "h", description: "Информация о командах сервера.", adminOnly: false)]
        public static void help(ChatCommandContext ctx)
        {
            string message1 = "<color=#37DE6A>Команды сервера:</color> \n";
            message1 += "<color=#ff0>\".br \" (.b) - Восстановит вам здоровье, кровь и способности.</color>\n";
            message1 += "<color=#ff0>\".tp nameArena\" - Телепортирует на указанную арену.</color>\n";
            message1 += "<color=#ff0>\".tp list\" - Весь список доступных арен.</color>\n";
            message1 += "<color=#ff0>\".kit\" - Выдаст броню, оружие и случайный плащь.</color>\n";


            string message2 = "<color=#FF0000>Рейтинговая игра:</color>\n";
            message2 += "<color=#E339A4>\".r\" - Зарегистрирует вас на арену или отменит регистрацию.</color>\n";
            message2 += "<color=#E339A4>\".r info\" - Таблица лидеров и ваша позиция в ней.</color>\n";

            ctx.Reply(message1);
            ctx.Reply(message2);
            ctx.Reply("<color=#E339A4>Наш дискорд: https://discord.gg/EXKGV52csa</color>");
        }
    }
}