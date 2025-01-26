namespace SnackFlix.Api.Reviews;

public class ReviewType : ObjectType<Review>
{
    protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
    {
        descriptor
            .Field(f => f.AccountId)
            .Authorize("IsOwner");
    }
}