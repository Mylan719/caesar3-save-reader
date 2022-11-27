using CeasarSaveReader.City.LabourData;
using CeasarSaveReader.Emperor;
using CeasarSaveReader.Game;
using CeasarSaveReader.Map;
using CeasarSaveReader.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.City
{
    public class CityLoader
    {
        public static CityData LoadMainData(Stream main, bool has_separate_import_limits)
        {
            var city_data = new CityData();

            var reader = new BinaryReader(main);

            city_data.unused.other_player = reader.ReadBytes(18068); //sbyta maybe
            city_data.unused.unknown_00a0 = reader.ReadSByte();
            city_data.unused.unknown_00a1 = reader.ReadSByte();
            city_data.unused.unknown_00a2 = reader.ReadSByte();
            city_data.unused.unknown_00a3 = reader.ReadSByte();
            city_data.unused.unknown_00a4 = reader.ReadSByte();
            city_data.building.unknown_value = reader.ReadSByte();
            city_data.unused.unknown_00a7 = reader.ReadSByte();
            city_data.unused.unknown_00a6 = reader.ReadSByte();
            city_data.finance.tax_percentage = reader.ReadInt32();
            city_data.finance.treasury = reader.ReadInt32();
            city_data.sentiment.value = reader.ReadInt32();
            city_data.health.target_value = reader.ReadInt32();
            city_data.health.value = reader.ReadInt32();
            city_data.health.num_hospital_workers = reader.ReadInt32();
            city_data.unused.unknown_00c0 = reader.ReadInt32();
            city_data.population.population = reader.ReadInt32();
            city_data.population.population_last_year = reader.ReadInt32();
            city_data.population.school_age = reader.ReadInt32();
            city_data.population.academy_age = reader.ReadInt32();
            city_data.population.total_capacity = reader.ReadInt32();
            city_data.population.room_in_houses = reader.ReadInt32();
            for (int i = 0; i < 2400; i++)
            {
                city_data.population.monthly.values[i] = reader.ReadInt32();
            }
            city_data.population.monthly.next_index = reader.ReadInt32();
            city_data.population.monthly.count = reader.ReadInt32();
            for (int i = 0; i < 100; i++)
            {
                city_data.population.at_age[i] = reader.ReadInt16();
            }
            for (int i = 0; i < 20; i++)
            {
                city_data.population.at_level[i] = reader.ReadInt32();
            }
            city_data.population.yearly_births = reader.ReadInt32();
            city_data.population.yearly_deaths = reader.ReadInt32();
            city_data.population.lost_removal = reader.ReadInt32();
            city_data.migration.immigration_amount_per_batch = reader.ReadInt32();
            city_data.migration.emigration_amount_per_batch = reader.ReadInt32();
            city_data.migration.emigration_queue_size = reader.ReadInt32();
            city_data.migration.immigration_queue_size = reader.ReadInt32();
            city_data.population.lost_homeless = reader.ReadInt32();
            city_data.population.last_change = reader.ReadInt32();
            city_data.population.average_per_year = reader.ReadInt32();
            city_data.population.total_all_years = reader.ReadInt32();
            city_data.population.people_in_tents_shacks = reader.ReadInt32();
            city_data.population.people_in_villas_palaces = reader.ReadInt32();
            city_data.population.total_years = reader.ReadInt32();
            city_data.population.yearly_update_requested = reader.ReadInt32();
            city_data.population.last_used_house_add = reader.ReadInt32();
            city_data.population.last_used_house_remove = reader.ReadInt32();
            city_data.migration.immigrated_today = reader.ReadInt32();
            city_data.migration.emigrated_today = reader.ReadInt32();
            city_data.migration.refused_immigrants_today = reader.ReadInt32();
            city_data.migration.percentage = reader.ReadInt32();
            city_data.culture.population_with_venus_access = reader.ReadInt32();
            city_data.migration.immigration_duration = reader.ReadInt32();
            city_data.migration.emigration_duration = reader.ReadInt32();
            city_data.migration.newcomers = reader.ReadInt32();
            city_data.culture.average_desirability = reader.ReadInt32();
            city_data.finance.tourism_rating = reader.ReadInt32();
            city_data.finance.tourism_last_month = reader.ReadInt32();
            city_data.finance.tourism_last_year = reader.ReadInt32();
            city_data.finance.tourism_this_year = reader.ReadInt16();
            city_data.resource.last_used_warehouse = reader.ReadInt16();
            city_data.trade.months_since_last_land_trade_problem = reader.ReadUInt16();
            city_data.trade.months_since_last_sea_trade_problem = reader.ReadUInt16();
            if (has_separate_import_limits)
            {
                for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
                {
                    city_data.resource.import_over[i] = reader.ReadInt16();
                }
            }
            else
            {
                for (int i = 0; i < 16; i++)
                {
                    city_data.unused.unknown_27f4[i] = reader.ReadInt16();
                }
            }
            city_data.map.entry_point.x = reader.ReadByte();
            city_data.map.entry_point.y = reader.ReadByte();
            city_data.map.entry_point.grid_offset = reader.ReadInt16();
            city_data.map.exit_point.x = reader.ReadByte();
            city_data.map.exit_point.y = reader.ReadByte();
            city_data.map.exit_point.grid_offset = reader.ReadInt16();
            city_data.building.senate_x = reader.ReadByte();
            city_data.building.senate_y = reader.ReadByte();
            city_data.building.senate_grid_offset = reader.ReadInt16();
            city_data.building.senate_building_id = reader.ReadInt32();
            city_data.trade.land_policy = reader.ReadByte();
            city_data.trade.sea_policy = reader.ReadByte();
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.space_in_warehouses[i] = reader.ReadInt16();
            }
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.stored_in_warehouses[i] = reader.ReadInt16();
            }
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.trade_status[i] = reader.ReadInt16();
            }
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.export_over[i] = reader.ReadInt16();
            }
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.mothballed[i] = reader.ReadInt16();
            }
            city_data.unused.unused_28ca = reader.ReadInt16();
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX_FOOD; i++)
            {
                city_data.resource.granary_food_stored[i] = reader.ReadInt32();
            }
            for (int i = 0; i < 6; i++)
            {
                city_data.resource.stored_in_workshops[i] = reader.ReadInt32();
            }
            for (int i = 0; i < 6; i++)
            {
                city_data.resource.space_in_workshops[i] = reader.ReadInt32();
            }
            city_data.resource.granary_total_stored = reader.ReadInt32();
            city_data.resource.food_types_available = reader.ReadInt32();
            city_data.resource.food_types_eaten = reader.ReadInt32();
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.export_status_before_stockpiling[i] = reader.ReadInt16();
            }
            for (int i = 0; i < 231; i++)
            {
                city_data.unused.unknown_2924[i] = reader.ReadSByte();
            }
            city_data.sentiment.crime_cooldown = reader.ReadSByte();
            city_data.building.caravanserai_building_id = reader.ReadInt32();
            city_data.caravanserai.total_food = reader.ReadInt32();
            for (int i = 0; i < (int)ResourceType.RESOURCE_MAX; i++)
            {
                city_data.resource.stockpiled[i] = reader.ReadInt32();
            }
            city_data.resource.food_supply_months = reader.ReadInt32();
            city_data.resource.granaries.operating = reader.ReadInt32();
            city_data.population.percentage_plebs = reader.ReadInt32();
            city_data.population.working_age = reader.ReadInt32();
            city_data.labor.workers_available = reader.ReadInt32();
            for (int i = 0; i < 10; i++)
            {
                var category = new LaborCategoryData();
                category.workers_needed = reader.ReadInt32();
                category.workers_allocated = reader.ReadInt32();
                category.total_houses_covered = reader.ReadInt32();
                category.buildings = reader.ReadInt32();
                category.priority = reader.ReadInt32();
                city_data.labor.categories[i] = category;
            }
            city_data.labor.workers_employed = reader.ReadInt32();
            city_data.labor.workers_unemployed = reader.ReadInt32();
            city_data.labor.unemployment_percentage = reader.ReadInt32();
            city_data.labor.unemployment_percentage_for_senate = reader.ReadInt32();
            city_data.labor.workers_needed = reader.ReadInt32();
            city_data.labor.wages = reader.ReadInt32();
            city_data.labor.wages_rome = reader.ReadInt32();
            city_data.labor.months_since_last_wage_change = reader.ReadInt32();
            city_data.finance.wages_so_far = reader.ReadInt32();
            city_data.finance.this_year.expenses.wages = reader.ReadInt32();
            city_data.finance.last_year.expenses.wages = reader.ReadInt32();
            city_data.taxes.taxed_plebs = reader.ReadInt32();
            city_data.taxes.taxed_patricians = reader.ReadInt32();
            city_data.taxes.untaxed_plebs = reader.ReadInt32();
            city_data.taxes.untaxed_patricians = reader.ReadInt32();
            city_data.taxes.percentage_taxed_plebs = reader.ReadInt32();
            city_data.taxes.percentage_taxed_patricians = reader.ReadInt32();
            city_data.taxes.percentage_taxed_people = reader.ReadInt32();
            city_data.taxes.yearly.collected_plebs = reader.ReadInt32();
            city_data.taxes.yearly.collected_patricians = reader.ReadInt32();
            city_data.taxes.yearly.uncollected_plebs = reader.ReadInt32();
            city_data.taxes.yearly.uncollected_patricians = reader.ReadInt32();
            city_data.finance.this_year.income.taxes = reader.ReadInt32();
            city_data.finance.last_year.income.taxes = reader.ReadInt32();
            city_data.taxes.monthly.collected_plebs = reader.ReadInt32();
            city_data.taxes.monthly.uncollected_plebs = reader.ReadInt32();
            city_data.taxes.monthly.collected_patricians = reader.ReadInt32();
            city_data.taxes.monthly.uncollected_patricians = reader.ReadInt32();
            city_data.finance.this_year.income.exports = reader.ReadInt32();
            city_data.finance.last_year.income.exports = reader.ReadInt32();
            city_data.finance.this_year.expenses.imports = reader.ReadInt32();
            city_data.finance.last_year.expenses.imports = reader.ReadInt32();
            city_data.finance.interest_so_far = reader.ReadInt32();
            city_data.finance.last_year.expenses.interest = reader.ReadInt32();
            city_data.finance.this_year.expenses.interest = reader.ReadInt32();
            city_data.finance.last_year.expenses.sundries = reader.ReadInt32();
            city_data.finance.this_year.expenses.sundries = reader.ReadInt32();
            city_data.finance.last_year.expenses.construction = reader.ReadInt32();
            city_data.finance.this_year.expenses.construction = reader.ReadInt32();
            city_data.finance.last_year.expenses.salary = reader.ReadInt32();
            city_data.finance.this_year.expenses.salary = reader.ReadInt32();
            city_data.emperor.salary_amount = reader.ReadInt32();
            city_data.emperor.salary_rank = reader.ReadInt32();
            city_data.finance.salary_so_far = reader.ReadInt32();
            city_data.finance.last_year.income.total = reader.ReadInt32();
            city_data.finance.this_year.income.total = reader.ReadInt32();
            city_data.finance.last_year.expenses.total = reader.ReadInt32();
            city_data.finance.this_year.expenses.total = reader.ReadInt32();
            city_data.finance.last_year.net_in_out = reader.ReadInt32();
            city_data.finance.this_year.net_in_out = reader.ReadInt32();
            city_data.finance.last_year.balance = reader.ReadInt32();
            city_data.finance.this_year.balance = reader.ReadInt32();
            for (int i = 0; i < 1400; i++)
            {
                city_data.unused.unknown_2c20[i] = reader.ReadInt32();
            }
            for (int i = 0; i < 8; i++)
            {
                city_data.unused.houses_requiring_unknown_to_evolve[i] = reader.ReadInt32();
            }
            city_data.trade.caravan_import_resource = reader.ReadInt32();
            city_data.trade.caravan_backup_import_resource = reader.ReadInt32();
            city_data.ratings.culture = reader.ReadInt32();
            city_data.ratings.prosperity = reader.ReadInt32();
            city_data.ratings.peace = reader.ReadInt32();
            city_data.ratings.favor = reader.ReadInt32();
            city_data.finance.levies_so_far = reader.ReadInt32();
            city_data.finance.this_year.expenses.levies = reader.ReadInt32();
            city_data.finance.last_year.expenses.levies = reader.ReadInt32();
            city_data.unused.unknown_4238[0] = reader.ReadInt32();
            city_data.ratings.prosperity_treasury_last_year = reader.ReadInt32();
            city_data.ratings.culture_points.theater = reader.ReadInt32();
            city_data.ratings.culture_points.religion = reader.ReadInt32();
            city_data.ratings.culture_points.school = reader.ReadInt32();
            city_data.ratings.culture_points.library = reader.ReadInt32();
            city_data.ratings.culture_points.academy = reader.ReadInt32();
            city_data.ratings.peace_num_criminals = reader.ReadInt32();
            city_data.ratings.peace_num_rioters = reader.ReadInt32();
            city_data.houses.missing.fountain = reader.ReadInt32();
            city_data.houses.missing.well = reader.ReadInt32();
            city_data.houses.missing.more_entertainment = reader.ReadInt32();
            city_data.houses.missing.more_education = reader.ReadInt32();
            city_data.houses.missing.education = reader.ReadInt32();
            city_data.houses.requiring.school = reader.ReadInt32();
            city_data.houses.requiring.library = reader.ReadInt32();
            city_data.games.bet_amount = reader.ReadInt32();
            city_data.houses.missing.barber = reader.ReadInt32();
            city_data.houses.missing.bathhouse = reader.ReadInt32();
            city_data.houses.missing.food = reader.ReadInt32();
            for (int i = 0; i < 2; i++)
            {
                city_data.unused.unknown_4294[i] = reader.ReadInt32();
            }
            city_data.building.hippodrome_placed = reader.ReadInt32();
            city_data.houses.missing.clinic = reader.ReadInt32();
            city_data.houses.missing.hospital = reader.ReadInt32();
            city_data.houses.requiring.barber = reader.ReadInt32();
            city_data.houses.requiring.bathhouse = reader.ReadInt32();
            city_data.houses.requiring.clinic = reader.ReadInt32();
            city_data.houses.missing.religion = reader.ReadInt32();
            city_data.houses.missing.second_religion = reader.ReadInt32();
            city_data.houses.missing.third_religion = reader.ReadInt32();
            city_data.houses.requiring.religion = reader.ReadInt32();
            city_data.entertainment.theater_shows = reader.ReadInt32();
            city_data.entertainment.theater_no_shows_weighted = reader.ReadInt32();
            city_data.entertainment.amphitheater_shows = reader.ReadInt32();
            city_data.entertainment.amphitheater_no_shows_weighted = reader.ReadInt32();
            city_data.entertainment.colosseum_shows = reader.ReadInt32();
            city_data.entertainment.colosseum_no_shows_weighted = reader.ReadInt32();
            city_data.entertainment.hippodrome_shows = reader.ReadInt32();
            city_data.entertainment.hippodrome_no_shows_weighted = reader.ReadInt32();
            city_data.entertainment.venue_needing_shows = reader.ReadInt32();
            city_data.culture.average_entertainment = reader.ReadInt32();
            city_data.houses.missing.entertainment = reader.ReadInt32();
            city_data.festival.months_since_festival = reader.ReadInt32();
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].target_happiness = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].happiness = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].wrath_bolts = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].blessing_done = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].small_curse_done = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].happy_bolts = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].unused2 = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].unused3 = reader.ReadSByte();
            }
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                city_data.religion.gods[i].months_since_festival = reader.ReadInt32();
            }
            city_data.religion.least_happy_god = reader.ReadInt32();
            city_data.unused.unknown_4334 = reader.ReadInt32();
            city_data.migration.no_immigration_cause = reader.ReadInt32();
            city_data.sentiment.protesters = reader.ReadInt32();
            city_data.sentiment.criminals = reader.ReadInt32();
            city_data.houses.health = reader.ReadInt32();
            city_data.houses.religion = reader.ReadInt32();
            city_data.houses.education = reader.ReadInt32();
            city_data.houses.entertainment = reader.ReadInt32();
            city_data.figure.rioters = reader.ReadInt32();
            city_data.ratings.selected = reader.ReadInt32();
            city_data.ratings.culture_explanation = reader.ReadInt32();
            city_data.ratings.prosperity_explanation = reader.ReadInt32();
            city_data.ratings.peace_explanation = reader.ReadInt32();
            city_data.ratings.favor_explanation = reader.ReadInt32();
            city_data.emperor.player_rank = reader.ReadInt32();
            city_data.emperor.personal_savings = reader.ReadInt32();
            for (int i = 0; i < 2; i++)
            {
                city_data.unused.unknown_4374[i] = reader.ReadInt32();
            }
            city_data.finance.last_year.income.donated = reader.ReadInt32();
            city_data.finance.this_year.income.donated = reader.ReadInt32();
            city_data.emperor.donate_amount = reader.ReadInt32();
            for (int i = 0; i < 10; i++)
            {
                city_data.building.working_dock_ids[i] = reader.ReadInt16();
            }
            city_data.building.months_since_last_destroyed_iron_mine = reader.ReadUInt16();
            city_data.building.months_since_last_flooded_clay_pit = reader.ReadUInt16();
            city_data.sentiment.blessing_festival_boost = reader.ReadInt16();
            city_data.figure.animals = reader.ReadInt16();
            city_data.trade.num_sea_routes = reader.ReadInt16();
            city_data.trade.num_land_routes = reader.ReadInt16();
            city_data.trade.sea_trade_problem_duration = reader.ReadInt16();
            city_data.trade.land_trade_problem_duration = reader.ReadInt16();
            city_data.building.working_docks = reader.ReadInt16();
            city_data.building.senate_placed = reader.ReadInt16();
            city_data.building.working_wharfs = reader.ReadInt16();

            for (int i = 0; i < 2; i++)
            {
                city_data.unused.padding_43b2[i] = reader.ReadSByte();
            }
            city_data.finance.stolen_this_year = reader.ReadInt16();
            city_data.finance.stolen_last_year = reader.ReadInt16();
            city_data.trade.docker_import_resource = reader.ReadInt32();
            city_data.trade.docker_export_resource = reader.ReadInt32();
            city_data.emperor.debt_state = reader.ReadInt32();
            city_data.emperor.months_in_debt = reader.ReadInt32();
            city_data.finance.cheated_money = reader.ReadInt32();
            city_data.building.barracks_x = reader.ReadSByte();
            city_data.building.barracks_y = reader.ReadSByte();
            city_data.building.barracks_grid_offset = reader.ReadInt16();
            city_data.building.barracks_building_id = reader.ReadInt32();
            city_data.building.barracks_placed = reader.ReadInt32();
            city_data.building.mess_hall_building_id = reader.ReadInt32();
            city_data.entertainment.arena_shows = reader.ReadInt32();
            city_data.entertainment.arena_no_shows_weighted = reader.ReadInt32();
            for (int i = 0; i < 2; i++)
            {
                city_data.unused.unknown_43d8[i] = reader.ReadInt32();
            }
            city_data.population.lost_troop_request = reader.ReadInt32();
            city_data.unused.unknown_43f0 = reader.ReadInt32();
            city_data.mission.has_won = reader.ReadInt32();
            city_data.mission.continue_months_left = reader.ReadInt32();
            city_data.mission.continue_months_chosen = reader.ReadInt32();
            city_data.finance.wage_rate_paid_this_year = reader.ReadInt32();
            city_data.finance.this_year.expenses.tribute = reader.ReadInt32();
            city_data.finance.last_year.expenses.tribute = reader.ReadInt32();
            city_data.finance.tribute_not_paid_last_year = reader.ReadInt32();
            city_data.finance.tribute_not_paid_total_years = reader.ReadInt32();
            city_data.festival.selected.god = reader.ReadInt32();
            city_data.festival.selected.size = reader.ReadInt32();
            city_data.festival.planned.size = reader.ReadInt32();
            city_data.festival.planned.months_to_go = reader.ReadInt32();
            city_data.festival.planned.god = reader.ReadInt32();
            city_data.festival.small_cost = reader.ReadInt32();
            city_data.festival.large_cost = reader.ReadInt32();
            city_data.festival.grand_cost = reader.ReadInt32();
            city_data.festival.grand_wine = reader.ReadInt32();
            city_data.festival.not_enough_wine = reader.ReadInt32();
            city_data.culture.average_religion = reader.ReadInt32();
            city_data.culture.average_education = reader.ReadInt32();
            city_data.culture.average_health = reader.ReadInt32();
            city_data.culture.religion_coverage = reader.ReadInt32();
            city_data.festival.first_festival_effect_months = reader.ReadInt32();
            city_data.festival.second_festival_effect_months = reader.ReadInt32();
            city_data.unused.unused_4454 = reader.ReadInt32();
            city_data.sentiment.unemployment = reader.ReadInt32();
            city_data.sentiment.previous_value = reader.ReadInt32();
            city_data.sentiment.message_delay = reader.ReadInt32();
            city_data.sentiment.low_mood_cause = reader.ReadInt32();
            city_data.figure.security_breach_duration = reader.ReadInt32();
            city_data.health.population_access.clinic = reader.ReadInt32();
            city_data.health.population_access.baths = reader.ReadInt32();
            city_data.health.population_access.barber = reader.ReadInt32();
            city_data.health.months_since_last_contaminated_water = reader.ReadInt32();
            city_data.emperor.selected_gift_size = reader.ReadInt32();
            city_data.emperor.months_since_gift = reader.ReadInt32();
            city_data.emperor.gift_overdose_penalty = reader.ReadInt32();
            city_data.unused.unused_4488 = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Modest].id = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Generous].id = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Lavish].id = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Modest].cost = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Generous].cost = reader.ReadInt32();
            city_data.emperor.gifts[(int)GiftType.Lavish].cost = reader.ReadInt32();
            city_data.ratings.favor_salary_penalty = reader.ReadInt32();
            city_data.ratings.favor_milestone_penalty = reader.ReadInt32();
            city_data.ratings.favor_ignored_request_penalty = reader.ReadInt32();
            city_data.ratings.favor_last_year = reader.ReadInt32();
            city_data.ratings.favor_change = reader.ReadInt32();
            city_data.military.native_attack_duration = reader.ReadInt32();
            city_data.unused.unused_native_force_attack = reader.ReadInt32();
            city_data.building.mission_post_operational = reader.ReadInt32();
            city_data.building.main_native_meeting = new MapPoint(reader.ReadInt32(), reader.ReadInt32());
            city_data.finance.wage_rate_paid_last_year = reader.ReadInt32();
            city_data.resource.food_needed_per_month = reader.ReadInt32();
            city_data.resource.granaries.understaffed = reader.ReadInt32();
            city_data.resource.granaries.not_operating = reader.ReadInt32();
            city_data.resource.granaries.not_operating_with_food = reader.ReadInt32();
            city_data.unused.unused_44e0[0] = reader.ReadInt32();
            city_data.religion.venus_blessing_months_left = reader.ReadInt32();
            city_data.religion.venus_curse_active = reader.ReadInt32();
            city_data.building.num_striking_industries = reader.ReadInt32();
            city_data.religion.neptune_double_trade_active = reader.ReadInt32();
            city_data.religion.mars_spirit_power = reader.ReadInt32();
            city_data.unused.unused_44f8 = reader.ReadInt32();
            city_data.religion.angry_message_delay = reader.ReadInt32();
            city_data.resource.food_consumed_last_month = reader.ReadInt32();
            city_data.resource.food_produced_last_month = reader.ReadInt32();
            city_data.resource.food_produced_this_month = reader.ReadInt32();
            city_data.ratings.peace_riot_cause = reader.ReadInt32();
            city_data.finance.estimated_tax_income = reader.ReadInt32();
            city_data.mission.tutorial_senate_built = reader.ReadInt32();
            city_data.building.distribution_center_x = reader.ReadSByte();
            city_data.building.distribution_center_y = reader.ReadSByte();
            city_data.building.distribution_center_grid_offset = reader.ReadInt16();
            city_data.building.distribution_center_building_id = reader.ReadInt32();
            city_data.building.distribution_center_placed = reader.ReadInt32();
            city_data.mess_hall.food_types = reader.ReadInt32();
            city_data.mess_hall.food_stress_cumulative = reader.ReadInt32();
            city_data.mess_hall.mess_hall_warning_shown = reader.ReadInt32();
            city_data.mess_hall.food_percentage_missing_this_month = reader.ReadInt32();
            city_data.mess_hall.total_food = reader.ReadInt32();
            city_data.mess_hall.missing_mess_hall_warning_shown = reader.ReadInt32();
            city_data.military.soldiers_in_city = reader.ReadInt32();
            city_data.games.naval_battle_distant_battle_bonus = reader.ReadInt32();
            city_data.figure.looters = reader.ReadInt32();
            city_data.figure.robbers = reader.ReadInt32();
            city_data.figure.protesters = reader.ReadInt32();
            city_data.building.shipyard_boats_requested = reader.ReadInt32();
            city_data.figure.enemies = reader.ReadInt32();
            city_data.sentiment.wages = reader.ReadInt32();
            city_data.population.people_in_tents = reader.ReadInt32();
            city_data.population.people_in_large_insula_and_above = reader.ReadInt32();
            city_data.figure.imperial_soldiers = reader.ReadInt32();
            city_data.emperor.invasion.duration_day_countdown = reader.ReadInt32();
            city_data.emperor.invasion.warnings_given = reader.ReadInt32();
            city_data.emperor.invasion.days_until_invasion = reader.ReadInt32();
            city_data.emperor.invasion.retreat_message_shown = reader.ReadInt32();
            city_data.ratings.peace_destroyed_buildings = reader.ReadInt32();
            city_data.ratings.peace_years_of_peace = reader.ReadInt32();
            city_data.distant_battle.city = reader.ReadByte();
            city_data.distant_battle.enemy_strength = reader.ReadByte();
            city_data.distant_battle.roman_strength = reader.ReadByte();
            city_data.distant_battle.months_until_battle = reader.ReadSByte();
            city_data.distant_battle.roman_months_to_travel_back = reader.ReadSByte();
            city_data.distant_battle.roman_months_to_travel_forth = reader.ReadSByte();
            city_data.distant_battle.city_foreign_months_left = reader.ReadSByte();
            city_data.building.triumphal_arches_available = reader.ReadSByte();
            city_data.distant_battle.total_count = reader.ReadSByte();
            city_data.distant_battle.won_count = reader.ReadSByte();
            city_data.distant_battle.enemy_months_traveled = reader.ReadSByte();
            city_data.distant_battle.roman_months_traveled = reader.ReadSByte();
            city_data.military.total_legions = reader.ReadByte();
            city_data.military.empire_service_legions = reader.ReadByte();
            city_data.games.chosen_horse = reader.ReadByte();
            city_data.military.total_soldiers = reader.ReadByte();
            city_data.building.triumphal_arches_placed = reader.ReadSByte();
            city_data.sound.die_citizen = reader.ReadSByte();
            city_data.sound.die_soldier = reader.ReadSByte();
            city_data.sound.shoot_arrow = reader.ReadSByte();
            city_data.building.trade_center_building_id = reader.ReadInt32();
            city_data.figure.soldiers = reader.ReadInt32();
            city_data.sound.hit_soldier = reader.ReadSByte();
            city_data.sound.hit_spear = reader.ReadSByte();
            city_data.sound.hit_club = reader.ReadSByte();
            city_data.sound.march_enemy = reader.ReadSByte();
            city_data.sound.march_horse = reader.ReadSByte();
            city_data.sound.hit_elephant = reader.ReadSByte();
            city_data.sound.hit_axe = reader.ReadSByte();
            city_data.sound.hit_wolf = reader.ReadSByte();
            city_data.sound.march_wolf = reader.ReadSByte();
            for (int i = 0; i < 6; i++)
            {
                city_data.unused.unused_45a5[i] = reader.ReadSByte();
            }
            city_data.sentiment.include_tents = reader.ReadSByte();
            city_data.emperor.invasion.count = reader.ReadInt32();
            city_data.emperor.invasion.size = reader.ReadInt32();
            city_data.emperor.invasion.soldiers_killed = reader.ReadInt32();
            city_data.military.legionary_legions = reader.ReadInt32();
            city_data.population.highest_ever = reader.ReadInt32();
            city_data.finance.estimated_wages = reader.ReadInt32();
            city_data.resource.wine_types_available = reader.ReadInt32();
            city_data.ratings.prosperity_max = reader.ReadInt32();
            for (int i = 0; i < 10; i++)
            {
                city_data.map.largest_road_networks[i].id = reader.ReadInt32();
                city_data.map.largest_road_networks[i].size = reader.ReadInt32();
            }
            city_data.houses.missing.second_wine = reader.ReadInt32();
            city_data.religion.neptune_sank_ships = reader.ReadInt32();
            city_data.entertainment.hippodrome_has_race = reader.ReadInt32();
            city_data.entertainment.hippodrome_message_shown = reader.ReadInt32();
            city_data.entertainment.colosseum_message_shown = reader.ReadInt32();
            city_data.migration.emigration_message_shown = reader.ReadInt32();
            city_data.mission.fired_message_shown = reader.ReadInt32();
            city_data.mission.victory_message_shown = reader.ReadInt32();
            city_data.mission.start_saved_game_written = reader.ReadInt32();
            city_data.mission.tutorial_fire_message_shown = reader.ReadInt32();
            city_data.mission.tutorial_disease_message_shown = reader.ReadInt32();
            city_data.figure.attacking_natives = reader.ReadInt32();
            for (int i = 0; i < 232; i++)
            {
                city_data.unused.unknown_464c[i] = reader.ReadSByte();
            }
            if (!has_separate_import_limits)
            {
                for (int i = (int)ResourceType.RESOURCE_MIN; i < (int)ResourceType.RESOURCE_MAX; i++)
                {
                    if (city_data.resource.trade_status[i] == (int)TradeStatus.Import)
                    {
                        city_data.resource.import_over[i] = city_data.resource.export_over[i];
                        city_data.resource.export_over[i] = 0;
                    }
                    else
                    {
                        city_data.resource.import_over[i] = 0;
                    }
                }
            }
            return city_data;
        }
    }
}
