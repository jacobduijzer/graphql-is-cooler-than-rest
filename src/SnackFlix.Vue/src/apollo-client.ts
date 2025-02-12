import { ApolloClient, InMemoryCache, HttpLink } from "@apollo/client/core";

const apolloClient = new ApolloClient({
    link: new HttpLink({
        uri: "https://localhost:7066/graphql/", // Public GraphQL API
    }),
    cache: new InMemoryCache(),
});

export default apolloClient;