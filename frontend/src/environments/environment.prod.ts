export const environment = {
  production: true,
  apiUrl: 'http://localhost:5000',
  keycloak: {
        url: 'http://keycloak:8080/auth',
        realm: 'products_api',
        clientId: 'api',
  }
};
