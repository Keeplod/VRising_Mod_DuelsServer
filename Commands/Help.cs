using VampireCommandFramework;

namespace DuelsServer.Commands
{
    public static class Help
    {
        [Command("help", "h", description: "Информация о командах сервера.", adminOnly: false)]
        public static void help(ChatCommandContext ctx)
        {
            string message = "\n<color=#37DE6A>Команды сервера:</color> \n";
            message += "<color=#ff0>\".br\" - Восстановит вам здоровье, кровь и кулдауны способностей.</color>\n";
            message += "<color=#ff0>\".tp nameArena\" - Телепортирует в указанную арену.</color>\n";
            message += "<color=#ff0>\".tp list\" - Весь список доступных арен.</color>\n";

            ctx.Reply(message);
        }
    }
}