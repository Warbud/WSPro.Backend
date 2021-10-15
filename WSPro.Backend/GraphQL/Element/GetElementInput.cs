namespace WSPro.Backend.GraphQL.Element
{
    public record GetElementInput(int Id);

    public record ElementModel(int RevitId, int Project);
}