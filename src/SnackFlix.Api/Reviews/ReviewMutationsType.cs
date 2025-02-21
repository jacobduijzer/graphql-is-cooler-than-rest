namespace SnackFlix.Api.Reviews;

public class ReviewMutationsType : ObjectTypeExtension<ReviewMutations>
{
    protected override void Configure(IObjectTypeDescriptor<ReviewMutations> descriptor)
    {
        descriptor
            .Field(f => f.Add(default, default))
            .Name("addReview")
            .Description("Add a review for a movie.")
            .Authorize();

        descriptor
            .Field(f => f.Delete(default))
            .Name("deleteReview")
            .Description("Delete a review for a movie. A review can only be deleted by the owner or an administrator.")
            .Authorize("IsOwnerOrAdmin");
    }
}