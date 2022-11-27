using CeasarSaveReader.Map;
using CeasarSaveReader.Scenario.Model;

namespace CeasarSaveReader.Scenario
{
    public class ScenarioLoader
    {
        public ScenarioData Load(Stream scenarioBuffer)
        {
            var reader = new BinaryReader(scenarioBuffer);
            var scenario = new ScenarioData();

            scenario.start_year = reader.ReadInt16();
            reader.ReadBytes(2);
            scenario.empire.id = reader.ReadInt16();
            reader.ReadBytes(8);

            // requests
            scenario.requests = new Request[Constants.MAX_REQUESTS];
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i] = new Request();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].year = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].resource = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].amount = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].deadline_years = reader.ReadInt16();
            }

            // invasions
            scenario.invasions = new Invasion[Constants.MAX_INVASIONS];
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i] = new Invasion();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].year = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].type = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].amount = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].from = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].attack_type = reader.ReadInt16();
            }

            reader.ReadBytes(2);
            scenario.initial_funds = reader.ReadInt32();
            scenario.enemy_id = reader.ReadInt16();
            reader.ReadBytes(6);

            scenario.map = new Model.Map(
                new Size(reader.ReadInt32(), reader.ReadInt32()),
                new GridOffset(reader.ReadInt32()),
                reader.ReadInt32());

            scenario.brief_description = new string(reader.ReadChars(Constants.MAX_BRIEF_DESCRIPTION));
            scenario.briefing = new string(reader.ReadChars(Constants.MAX_BRIEFING));

            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].can_comply_dialog_shown = reader.ReadByte();
            }

            scenario.image_id = reader.ReadInt16();
            scenario.is_open_play = reader.ReadInt16();
            scenario.player_rank = reader.ReadInt16();


            scenario.herd_points = ReadPoints(reader, Constants.MAX_HERD_POINTS);

            // demand changes
            scenario.demand_changes = new DemandChange[Constants.MAX_DEMAND_CHANGES];
            for (int i = 0; i < Constants.MAX_DEMAND_CHANGES; i++)
            {
                scenario.demand_changes[i] = new DemandChange();
                scenario.demand_changes[i].year = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_DEMAND_CHANGES; i++)
            {
                scenario.demand_changes[i].month = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_DEMAND_CHANGES; i++)
            {
                scenario.demand_changes[i].resource = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_DEMAND_CHANGES; i++)
            {
                scenario.demand_changes[i].route_id = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_DEMAND_CHANGES; i++)
            {
                scenario.demand_changes[i].is_rise = reader.ReadByte();
            }

            // price changes
            scenario.price_changes = new PriceChange[Constants.MAX_PRICE_CHANGES];
            for (int i = 0; i < Constants.MAX_PRICE_CHANGES; i++)
            {
                scenario.price_changes[i] = new PriceChange();
                scenario.price_changes[i].year = reader.ReadInt16();
            }
            for (int i = 0; i < Constants.MAX_PRICE_CHANGES; i++)
            {
                scenario.price_changes[i].month = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_PRICE_CHANGES; i++)
            {
                scenario.price_changes[i].resource = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_PRICE_CHANGES; i++)
            {
                scenario.price_changes[i].amount = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_PRICE_CHANGES; i++)
            {
                scenario.price_changes[i].is_rise = reader.ReadByte();
            }

            scenario.gladiator_revoult.enabled = reader.ReadInt32();
            scenario.gladiator_revoult.year = reader.ReadInt32();
            scenario.emperor_change.enabled = reader.ReadInt32();
            scenario.emperor_change.year = reader.ReadInt32();

            // random events
            scenario.random_events.sea_trade_problem = reader.ReadInt32();
            scenario.random_events.land_trade_problem = reader.ReadInt32();
            scenario.random_events.raise_wages = reader.ReadInt32();
            scenario.random_events.lower_wages = reader.ReadInt32();
            scenario.random_events.contaminated_water = reader.ReadInt32();
            scenario.random_events.iron_mine_collapse = reader.ReadInt32();
            scenario.random_events.clay_pit_flooded = reader.ReadInt32();

            scenario.fishing_points = ReadPoints(reader, Constants.MAX_FISH_POINTS);

            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].favor = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_INVASIONS; i++)
            {
                scenario.invasions[i].month = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].month = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].state = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].visible = reader.ReadByte();
            }
            for (int i = 0; i < Constants.MAX_REQUESTS; i++)
            {
                scenario.requests[i].months_to_comply = reader.ReadByte();
            }

            scenario.rome_supplies_wheat = reader.ReadInt32();

            // allowed buildings
            for (int i = 0; i < Constants.MAX_ALLOWED_BUILDINGS; i++)
            {
                scenario.allowed_buildings[i] = reader.ReadInt16();
            }

            // win criteria
            scenario.win_criteria.culture.goal = reader.ReadInt32();
            scenario.win_criteria.prosperity.goal = reader.ReadInt32();
            scenario.win_criteria.peace.goal = reader.ReadInt32();
            scenario.win_criteria.favor.goal = reader.ReadInt32();
            scenario.win_criteria.culture.enabled = reader.ReadByte();
            scenario.win_criteria.prosperity.enabled = reader.ReadByte();
            scenario.win_criteria.peace.enabled = reader.ReadByte();
            scenario.win_criteria.favor.enabled = reader.ReadByte();
            scenario.win_criteria.time_limit.enabled = reader.ReadInt32();
            scenario.win_criteria.time_limit.years = reader.ReadInt32();
            scenario.win_criteria.survival_time.enabled = reader.ReadInt32();
            scenario.win_criteria.survival_time.years = reader.ReadInt32();

            scenario.earthquake.severity = reader.ReadInt32();
            scenario.earthquake.year = reader.ReadInt32();

            scenario.win_criteria.population.enabled = reader.ReadInt32();
            scenario.win_criteria.population.goal = reader.ReadInt32();

            // map points
            scenario.earthquake_point = new MapPoint(reader.ReadInt16(), reader.ReadInt16());
            scenario.entry_point = new MapPoint(reader.ReadInt16(), reader.ReadInt16());
            scenario.exit_point = new MapPoint(reader.ReadInt16(), reader.ReadInt16());


            scenario.invasion_points = ReadPoints(reader, Constants.MAX_INVASION_POINTS);
           

            scenario.river_entry_point = new MapPoint(reader.ReadInt16(), reader.ReadInt16());
            scenario.river_exit_point = new MapPoint(reader.ReadInt16(), reader.ReadInt16());

            scenario.rescue_loan = reader.ReadInt32();
            scenario.win_criteria.milestone25_year = reader.ReadInt32();
            scenario.win_criteria.milestone50_year = reader.ReadInt32();
            scenario.win_criteria.milestone75_year = reader.ReadInt32();

            scenario.native_images.hut = reader.ReadInt32();
            scenario.native_images.meeting = reader.ReadInt32();
            scenario.native_images.crops = reader.ReadInt32();

            scenario.climate = reader.ReadByte();
            scenario.flotsam_enabled = reader.ReadByte()>0;

            reader.ReadBytes(2);

            scenario.empire.is_expanded = reader.ReadInt32();
            scenario.empire.expansion_year = reader.ReadInt32();

            scenario.empire.distant_battle_roman_travel_months = reader.ReadByte();
            scenario.empire.distant_battle_enemy_travel_months = reader.ReadByte();
            scenario.open_play_scenario_id = reader.ReadByte();
            reader.ReadBytes(1);

            scenario.is_saved = true;
            return scenario;
        }
        private int[] ReadInt16Array(BinaryReader reader, int count)
        {
            var list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(reader.ReadInt16());
            }
            return list.ToArray();
        }

        private MapPoint[] ReadPoints(BinaryReader reader, int count)
        {
            var XCoords = ReadInt16Array(reader, count);
            var YCoords = ReadInt16Array(reader, count);
            return XCoords.Zip(YCoords, (x, y) => new MapPoint(x, y))
                .ToArray();
        }
    }
}
