using CeasarSaveReader.Loader;
using CeasarSaveReader.Map;
using CeasarSaveReader.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.Figures.Model
{
    public class Figure : ItemBase<FigureState>
    {
        public uint image_id { get; set; }
        public uint cart_image_id { get; set; }
        public byte image_offset { get; set; }
        public byte is_enemy_image { get; set; }

        public byte alternative_location_index { get; set; }
        public byte flotsam_visible { get; set; }
        public short next_figure_id_on_same_tile { get; set; }
        public FigureType type { get; set; }
        public ResourceType ResourceId { get; set; }
        public byte use_cross_country { get; set; }
        public byte is_friendly { get; set; }
        public byte faction_id { get; set; } // 1 = city, 0 = enemy
        public byte action_state_before_attack { get; set; }
        public sbyte direction { get; set; }
        public sbyte previous_tile_direction { get; set; }
        public sbyte attack_direction { get; set; }
        public byte previous_tile_x { get; set; }
        public byte previous_tile_y { get; set; }
        public byte missile_damage { get; set; }
        public byte damage { get; set; }
        public GridOffset Destination { get; set; }
        public GridOffset GlobalDestination { get; set; } //destination_grid_offset: only used for soldiers
        public GridOffset Source { get; set; }
        public FormationPosition formation_position_x { get; set; } = new FormationPosition();
        public FormationPosition formation_position_y { get; set; } = new FormationPosition();
        public short disallow_diagonal { get; set; }
        public short wait_ticks { get; set; }
        public ActionState ActionState { get; set; }
        public byte progress_on_tile { get; set; }
        public short routing_path_id { get; set; }
        public short routing_path_current_tile { get; set; }
        public short routing_path_length { get; set; }
        public byte in_building_wait_ticks { get; set; }
        public bool IsOnRoad { get; set; }
        public short MaxRoamLength { get; set; }
        public int MaxRoamLengthTiles => MaxRoamLength / 15; //MaxRoamLength seems to be in ticks rather then tiles, there is 15 ticks for one tile traveled
        public short roam_length { get; set; }
        public byte roam_choose_destination { get; set; }
        public byte roam_random_counter { get; set; }
        public sbyte roam_turn_direction { get; set; }
        public sbyte roam_ticks_until_next_turn { get; set; }
        public short cross_country_x { get; set; } // position = 15 * x + offset on tile
        public short cross_country_y { get; set; } // position = 15 * y + offset on tile
        public short cc_destination_x { get; set; }
        public short cc_destination_y { get; set; }
        public short cc_delta_x { get; set; }
        public short cc_delta_y { get; set; }
        public short cc_delta_xy { get; set; }
        public byte cc_direction { get; set; } // 1 = x, 2 = y
        public byte speed_multiplier { get; set; }
        public short building_id { get; set; }
        public short immigrant_building_id { get; set; }
        public short DestinationBuildingId { get; set; }
        public short formation_id { get; set; }
        public byte index_in_formation { get; set; }
        public byte formation_at_rest { get; set; }
        public byte migrant_num_people { get; set; }
        public byte is_ghost { get; set; }
        public byte min_max_seen { get; set; }
        public sbyte progress_to_next_tick { get; set; }
        public short leading_figure_id { get; set; }
        public byte attack_image_offset { get; set; }
        public byte wait_ticks_missile { get; set; }
        public sbyte x_offset_cart { get; set; }
        public sbyte y_offset_cart { get; set; }
        public byte empire_city_id { get; set; }
        public byte trader_amount_bought { get; set; }
        public short name { get; set; }
        public TerrainUsage TerrainUsage { get; set; }
        public byte LoadsSoldOrCarrying { get; set; }
        public FloatingType Floating { get; set; }
        public byte height_adjusted_ticks { get; set; }
        public byte current_height { get; set; }
        public byte target_height { get; set; }
        public byte collecting_item_id { get; set; } // NOT a resource ID for cartpushers! IS a resource ID for warehousemen or lighthouse supplier
        public byte trade_ship_failed_dock_attempts { get; set; }
        public byte phrase_sequence_exact { get; set; }
        public sbyte phrase_id { get; set; }
        public byte phrase_sequence_city { get; set; }
        public byte trader_id { get; set; }
        public byte wait_ticks_next_target { get; set; }
        public byte dont_draw_elevated { get; set; }
        public short target_figure_id { get; set; }
        public short targeted_by_figure_id { get; set; }
        public ushort created_sequence { get; set; }
        public ushort target_figure_created_sequence { get; set; }
        public byte figures_on_same_tile_index { get; set; }
        public byte num_attackers { get; set; }
        public short attacker_id1 { get; set; }
        public short attacker_id2 { get; set; }
        public short opponent_id { get; set; }
        public Tourist tourist { get; set; } = new Tourist();

        public override string ToString() => $"t:{type}, a:{ActionState}, dest: {Destination} {base.ToString()}";
    }
}
