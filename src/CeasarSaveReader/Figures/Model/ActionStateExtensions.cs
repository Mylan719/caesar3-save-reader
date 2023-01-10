namespace CeasarSaveReader.Figures.Model
{
    public static class ActionStateExtensions
    {
        public static bool IsRoaming(this ActionState actionState)
            => actionState == ActionState.ROAMING
            || actionState == ActionState.ENGINEER_ROAMING
            || actionState == ActionState.ENTERTAINER_ROAMING
            || actionState == ActionState.PREFECT_ROAMING
            || actionState == ActionState.TAX_COLLECTOR_ROAMING;

        public static bool IsRoamerReturning(this ActionState actionState)
            => actionState == ActionState.ROAMER_RETURNING
            || actionState == ActionState.ENGINEER_RETURNING
            || actionState == ActionState.ENTERTAINER_RETURNING
            || actionState == ActionState.PREFECT_RETURNING
            || actionState == ActionState.TAX_COLLECTOR_RETURNING;

        public static bool IsAtDeliveryDestination(this ActionState actionState)
            => actionState == ActionState.CARTPUSHER_AT_WAREHOUSE ||
               actionState == ActionState.CARTPUSHER_AT_GRANARY ||
               actionState == ActionState.CARTPUSHER_AT_WORKSHOP;
    }
}
