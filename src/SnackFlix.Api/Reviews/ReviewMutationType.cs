namespace SnackFlix.Api.Reviews;

public class ReviewMutationType : ObjectType<ReviewMutations>
{
    protected override void Configure(IObjectTypeDescriptor<ReviewMutations> descriptor)
    {
        descriptor
            .Field(f => f.Add(default,  default))
            .Authorize();

        descriptor
            .Field(f => f.Delete(default))
            .Authorize("IsAdmin");
    }
}