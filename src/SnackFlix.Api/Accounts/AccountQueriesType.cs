namespace SnackFlix.Api.Accounts;

public class AccountQueriesType : ObjectTypeExtension<AccountQueries>
{
   protected override void Configure(IObjectTypeDescriptor<AccountQueries> descriptor)
   {
      descriptor
         .Field(f => f.Login(default, default))
         .AllowAnonymous();
   }
}