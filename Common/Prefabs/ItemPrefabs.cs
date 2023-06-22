using ProjectM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuelsServer.Common.Prefabs
{
    public static class IItemPrefabs
    {
        // Зелья
        public static readonly PrefabGUID Item_Consumable_GlassBottle_SpellBrew_T02 = new(1510182325); // Ведьмино зелье
        public static readonly PrefabGUID Item_Consumable_Canteen_SpellBrew_T01 = new(248289327); // Заколдованный отвар
        public static readonly PrefabGUID Item_Consumable_GlassBottle_PhysicalBrew_T02 = new(-1568756102); // Зелье ярости
        public static readonly PrefabGUID Item_Consumable_Canteen_PhysicalBrew_T01 = new(-269326085); // Отвар неистовства
        public static readonly PrefabGUID Item_Consumable_GlassBottle_BloodRosePotion_T02 = new(429052660); // Зелье кровавой розы
        public static readonly PrefabGUID Item_Consumable_Canteen_BloodRoseBrew_T01 = new(800879747); // Отвар кровавой розы
        public static readonly PrefabGUID Item_Consumable_Salve_Vermin = new(-1885959251); // Мазь от вредителей
        public static readonly PrefabGUID Item_Consumable_Canteen_MinorFireResistanceBrew_T01 = new(970650569); // Отвар защиты от огня
        public static readonly PrefabGUID Item_Consumable_PrisonPotion_Bloodwine = new(1223264867); // Кровавое мерло
        public static readonly PrefabGUID Item_Consumable_PrisonPotion = new(828432508); // Кровавое зелье
        public static readonly PrefabGUID FakeItem_Prisoner_ExtractedBloodPotion = new(1871776321); // Кровавое зелье

        // Броня
        public static readonly PrefabGUID Item_Chest_T08_Shadowmoon = new(488592933); // грудь
        public static readonly PrefabGUID Item_Gloves_T08_Shadowmoon = new(1634690081); // кисти
        public static readonly PrefabGUID Item_Legs_T08_Shadowmoon = new(1292986377); // ногти
        public static readonly PrefabGUID Item_Boots_T08_Shadowmoon = new(-556769032); // ступни

        // Шея
        public static readonly PrefabGUID Item_MagicSource_General_T08_FrozenCrypt = new(1380368392); // Амулет Архичернокнижника
        public static readonly PrefabGUID Item_MagicSource_General_T08_Beast = new(-296161379); // Амулет Мастера клинка
        public static readonly PrefabGUID Item_MagicSource_General_T08_CrimsonSky = new(-104934480); // Амулет Багрового командира
        public static readonly PrefabGUID Item_MagicSource_General_T08_Madness = new(-1004351840); // Амулет Непреклонного бойца
        public static readonly PrefabGUID Item_MagicSource_General_T08_Delusion = new(-1306155896); // Амулет верховной чародейки
        public static readonly PrefabGUID Item_MagicSource_General_T08_WickedProphet = new(-175650376); // Амулет нечестивого пророка

        // Оружие
        public static readonly PrefabGUID Item_Weapon_Sword_T08_Sanguine = new(-774462329); // Меч
        public static readonly PrefabGUID Item_Weapon_Spear_T08_Sanguine = new(-850142339); // Копьё
        public static readonly PrefabGUID Item_Weapon_Slashers_T08_Sanguine = new(1322545846); // Клинки
        public static readonly PrefabGUID Item_Weapon_Reaper_T08_Sanguine = new(-2053917766); // Коса
        public static readonly PrefabGUID Item_Weapon_Mace_T08_Sanguine = new(-126076280); // Булава
        public static readonly PrefabGUID Item_Weapon_Crossbow_T08_Sanguine = new(1389040540); // Арбалет
        public static readonly PrefabGUID Item_Weapon_Axe_T08_Sanguine = new(-2044057823); // Топоры
        public static readonly PrefabGUID Item_Weapon_Pistols_T08_Sanguine = new(1071656850); // Пистолеты
        public static readonly PrefabGUID Item_Weapon_GreatSword_T08_Sanguine = new(147836723); // Двуручный меч

        // Голова
        public static readonly PrefabGUID Item_Headgear_WolfTrophy01 = new(-1169471531); // Волчья голова
        public static readonly PrefabGUID Item_Headgear_WolfTrophy02 = new(-1785271534); // Волчья шляпа
        public static readonly PrefabGUID Item_Headgear_WerewolfTrophy = new(-2020831626); // Голова оборотня
        public static readonly PrefabGUID Item_Headgear_VampireHunterHat = new(974739126); // Шляпа охотника на вампиров
        public static readonly PrefabGUID Item_Headgear_GeneralHelmet = new(409678749); // Шлем мертвого генерала
        public static readonly PrefabGUID Item_Headgear_RustedMilitiaHelmet = new(764480170); // Шлем мертвого генерала
        public static readonly PrefabGUID Item_Headgear_TopHat = new(690259405); // Цилиндр
        public static readonly PrefabGUID Item_Headgear_Strawhat = new(1375804543); // Соломенная шляпа
        public static readonly PrefabGUID Item_Headgear_Scarecrow = new(403967307); // Маска пугала
        public static readonly PrefabGUID Item_Headgear_RustedHelmet = new(1364460757); // Ржавый шлем
        public static readonly PrefabGUID Item_Headgear_RazerHood = new(-1797796642); // Островерхий капюшон
        public static readonly PrefabGUID Item_Headgear_PilgrimsHat = new(-1071187362); // Шапка паломника
        public static readonly PrefabGUID Item_Headgear_PaladinsHelmet = new(1780339680); // Шлем паладина
        public static readonly PrefabGUID Item_Headgear_NightlurkerTrophy = new(-2073081569); // Шлем ночного скрытня
        public static readonly PrefabGUID Item_Headgear_NecromancerMitre = new(607559019); // Колпак некроманта
        public static readonly PrefabGUID Item_Headgear_PopeMitre = new(-548847761); // Колпак
        public static readonly PrefabGUID Item_Headgear_MilitiaHelmet = new(417648894); // Шлем ополченца
        public static readonly PrefabGUID Item_Headgear_MaidScarf = new(-1460281233); // Шарф служанки
        public static readonly PrefabGUID Item_Headgear_MaidCap = new(-1721887666); // Чепчик служанки
        public static readonly PrefabGUID Item_Headgear_KnightsHelmet = new(-1818243335); // Шлем рыцаря
        public static readonly PrefabGUID Item_Headgear_DraculaHelmet = new(238268650); // Великий шлем бессмертного короля
        public static readonly PrefabGUID Item_Headgear_FootmansHelmet = new(-353076115); // Шлем пехотинца
        public static readonly PrefabGUID Item_Headgear_DeerTrophy = new(1707139699); // Оленья голова
        public static readonly PrefabGUID Item_Headgear_ArcMageCrown = new(-2128818978); // Венец архимага
        public static readonly PrefabGUID Item_Headgear_Bonnet = new(-152150271); // Капор
        public static readonly PrefabGUID Item_Head_T01_Bone = new(-2111388989); // Маска костяного стража
        public static readonly PrefabGUID Item_Headgear_BearTrophy = new(714007172); // Медвежья голова
        public static readonly PrefabGUID Item_Headgear_AshfolkHelmet = new(-1607893829); // Шлем Эшфолка
        public static readonly PrefabGUID Item_Headgear_AshfolkCrown = new(-1988816037); // Корона Эшфолка

        // Плащи
        public static readonly PrefabGUID Item_Cloak_T02_WildlingBlue = new(239338934); // Ледяной плащ Эшфолка
        public static readonly PrefabGUID Item_Cloak_T02_WildlingRed = new(-1023114892); // Огненный плащ Эшфолка
        public static readonly PrefabGUID Item_Cloak_T02_Tailor = new(-2081646636); // Шарф Беатрисы
        public static readonly PrefabGUID Item_Cloak_T02_Cardinal = new(-1768698241); // Плащ кардинала
        public static readonly PrefabGUID Item_Cloak_T03_CrimsonWard = new(-1755568324); // Багровая пелерина
        public static readonly PrefabGUID Item_Cloak_T02_MilitiaMonk = new(2147390246); // Косынка отшельника
        public static readonly PrefabGUID Item_Cloak_Main_T02_Hunter = new(786585343); // Плащ охотника
        public static readonly PrefabGUID Item_Cloak_T02_Dracula = new(-1067360120); // Плащ бессмертного короля
        public static readonly PrefabGUID Item_Cloak_T03_Dracula = new(-1814109557); // Мантия бессмертного короля
        public static readonly PrefabGUID Item_Cloak_T02_HolyPaladin = new(-2091288477); // Косынка маны
        public static readonly PrefabGUID Item_Cloak_Main_T03_Phantom = new(-227965303); // Вуаль призрака
        public static readonly PrefabGUID Item_Cloak_T02_HarpyMatriarch = new(1677983904); // Капюшон с фиолетовыми перьями
        public static readonly PrefabGUID Item_Cloak_T03_Razer = new(136740861); // Островерхая мантия змея
        public static readonly PrefabGUID Item_Cloak_T03_Royal = new(584164197); // Мантия королей Эшфолка
        public static readonly PrefabGUID Item_Cloak_T03_Jester = new(379281083); // Королевская вуаль шута
        public static readonly PrefabGUID Item_Cloak_T03_UnholyShroud = new(1863126275); // Хвост сатаны
        public static readonly PrefabGUID Item_Cloak_T02_PatchedCloak = new(1275572025); // Шитый-перешитый плащ
        public static readonly PrefabGUID Item_Cloak_T02_Poloma = new(-589858836); // Капюшон с перьями токи
        public static readonly PrefabGUID Item_Cloak_T02_TornRags = new(707710831); // Истерзанный багровый плащ

        public static readonly System.Collections.Generic.List<PrefabGUID> consumableList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Consumable_GlassBottle_SpellBrew_T02,
            Item_Consumable_Canteen_SpellBrew_T01,
            Item_Consumable_GlassBottle_PhysicalBrew_T02,
            Item_Consumable_Canteen_PhysicalBrew_T01,
            Item_Consumable_GlassBottle_BloodRosePotion_T02,
            Item_Consumable_Canteen_BloodRoseBrew_T01,
            Item_Consumable_Salve_Vermin,
            Item_Consumable_Canteen_MinorFireResistanceBrew_T01,
            Item_Consumable_PrisonPotion_Bloodwine,
            Item_Consumable_PrisonPotion,
            FakeItem_Prisoner_ExtractedBloodPotion
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> equipmentList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Chest_T08_Shadowmoon,
            Item_Gloves_T08_Shadowmoon,
            Item_Legs_T08_Shadowmoon,
            Item_Boots_T08_Shadowmoon
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> magicSourceList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_MagicSource_General_T08_FrozenCrypt,
            Item_MagicSource_General_T08_Beast,
            Item_MagicSource_General_T08_CrimsonSky,
            Item_MagicSource_General_T08_Madness,
            Item_MagicSource_General_T08_Delusion,
            Item_MagicSource_General_T08_WickedProphet
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> weaponList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Weapon_Sword_T08_Sanguine,
            Item_Weapon_Spear_T08_Sanguine,
            Item_Weapon_Slashers_T08_Sanguine,
            Item_Weapon_Reaper_T08_Sanguine,
            Item_Weapon_Mace_T08_Sanguine,
            Item_Weapon_Crossbow_T08_Sanguine,
            Item_Weapon_Axe_T08_Sanguine,
            Item_Weapon_Pistols_T08_Sanguine,
            Item_Weapon_GreatSword_T08_Sanguine
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> headgearList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Headgear_WolfTrophy01,
            Item_Headgear_WolfTrophy02,
            Item_Headgear_WerewolfTrophy,
            Item_Headgear_VampireHunterHat,
            Item_Headgear_GeneralHelmet,
            Item_Headgear_RustedMilitiaHelmet,
            Item_Headgear_TopHat,
            Item_Headgear_Strawhat,
            Item_Headgear_Scarecrow,
            Item_Headgear_RustedHelmet,
            Item_Headgear_RazerHood,
            Item_Headgear_PilgrimsHat,
            Item_Headgear_PaladinsHelmet,
            Item_Headgear_NightlurkerTrophy,
            Item_Headgear_NecromancerMitre,
            Item_Headgear_PopeMitre,
            Item_Headgear_MilitiaHelmet,
            Item_Headgear_MaidScarf,
            Item_Headgear_MaidCap,
            Item_Headgear_KnightsHelmet,
            Item_Headgear_DraculaHelmet,
            Item_Headgear_FootmansHelmet,
            Item_Headgear_DeerTrophy,
            Item_Headgear_ArcMageCrown,
            Item_Headgear_Bonnet,
            Item_Head_T01_Bone,
            Item_Headgear_BearTrophy,
            Item_Headgear_AshfolkHelmet,
            Item_Headgear_AshfolkCrown
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> cloakList = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Cloak_T02_WildlingBlue,
            Item_Cloak_T02_WildlingRed,
            Item_Cloak_T02_Tailor,
            Item_Cloak_T02_Cardinal,
            Item_Cloak_T03_CrimsonWard,
            Item_Cloak_T02_MilitiaMonk,
            Item_Cloak_Main_T02_Hunter,
            Item_Cloak_T02_Dracula,
            Item_Cloak_T03_Dracula,
            Item_Cloak_T02_HolyPaladin,
            Item_Cloak_Main_T03_Phantom,
            Item_Cloak_T02_HarpyMatriarch,
            Item_Cloak_T03_Razer,
            Item_Cloak_T03_Royal,
            Item_Cloak_T03_Jester,
            Item_Cloak_T03_UnholyShroud,
            Item_Cloak_T02_PatchedCloak,
            Item_Cloak_T02_Poloma,
            Item_Cloak_T02_TornRags
        };

        public static readonly System.Collections.Generic.List<PrefabGUID> allArmors = new System.Collections.Generic.List<PrefabGUID>()
        {
            Item_Cloak_T02_WildlingBlue,
            Item_Cloak_T02_WildlingRed,
            Item_Cloak_T02_Tailor,
            Item_Cloak_T02_Cardinal,
            Item_Cloak_T03_CrimsonWard,
            Item_Cloak_T02_MilitiaMonk,
            Item_Cloak_Main_T02_Hunter,
            Item_Cloak_T02_Dracula,
            Item_Cloak_T03_Dracula,
            Item_Cloak_T02_HolyPaladin,
            Item_Cloak_Main_T03_Phantom,
            Item_Cloak_T02_HarpyMatriarch,
            Item_Cloak_T03_Razer,
            Item_Cloak_T03_Royal,
            Item_Cloak_T03_Jester,
            Item_Cloak_T03_UnholyShroud,
            Item_Cloak_T02_PatchedCloak,
            Item_Cloak_T02_Poloma,
            Item_Cloak_T02_TornRags,
            Item_Headgear_WolfTrophy01,
            Item_Headgear_WolfTrophy02,
            Item_Headgear_WerewolfTrophy,
            Item_Headgear_VampireHunterHat,
            Item_Headgear_GeneralHelmet,
            Item_Headgear_RustedMilitiaHelmet,
            Item_Headgear_TopHat,
            Item_Headgear_Strawhat,
            Item_Headgear_Scarecrow,
            Item_Headgear_RustedHelmet,
            Item_Headgear_RazerHood,
            Item_Headgear_PilgrimsHat,
            Item_Headgear_PaladinsHelmet,
            Item_Headgear_NightlurkerTrophy,
            Item_Headgear_NecromancerMitre,
            Item_Headgear_PopeMitre,
            Item_Headgear_MilitiaHelmet,
            Item_Headgear_MaidScarf,
            Item_Headgear_MaidCap,
            Item_Headgear_KnightsHelmet,
            Item_Headgear_DraculaHelmet,
            Item_Headgear_FootmansHelmet,
            Item_Headgear_DeerTrophy,
            Item_Headgear_ArcMageCrown,
            Item_Headgear_Bonnet,
            Item_Head_T01_Bone,
            Item_Headgear_BearTrophy,
            Item_Headgear_AshfolkHelmet,
            Item_Headgear_AshfolkCrown,
            Item_Weapon_Sword_T08_Sanguine,
            Item_Weapon_Spear_T08_Sanguine,
            Item_Weapon_Slashers_T08_Sanguine,
            Item_Weapon_Reaper_T08_Sanguine,
            Item_Weapon_Mace_T08_Sanguine,
            Item_Weapon_Crossbow_T08_Sanguine,
            Item_Weapon_Axe_T08_Sanguine,
            Item_Weapon_Pistols_T08_Sanguine,
            Item_Weapon_GreatSword_T08_Sanguine,
            Item_MagicSource_General_T08_FrozenCrypt,
            Item_MagicSource_General_T08_Beast,
            Item_MagicSource_General_T08_CrimsonSky,
            Item_MagicSource_General_T08_Madness,
            Item_MagicSource_General_T08_Delusion,
            Item_MagicSource_General_T08_WickedProphet,
            Item_Chest_T08_Shadowmoon,
            Item_Gloves_T08_Shadowmoon,
            Item_Legs_T08_Shadowmoon,
            Item_Boots_T08_Shadowmoon
        };
    }
}
