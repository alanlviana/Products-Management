import { KeycloakService } from 'keycloak-angular';

import { environment } from '../../environments/environment';

export function keycloakInitializer(keycloak: KeycloakService): () => Promise<any> {
    return (): Promise<any> => {
        return new Promise(async (resolve, reject) => {
            try {
                await keycloak.init({
                    config: environment.keycloak,
                    initOptions: {
                        checkLoginIframe: false
                    },
                    bearerExcludedUrls: []
                });
                resolve(null);
            } catch (error) {
                reject(error);
            }
        });
    };
}