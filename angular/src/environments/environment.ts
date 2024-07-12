import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Library',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44384/',
    redirectUri: baseUrl,
    clientId: 'Library_App',
    responseType: 'code',
    scope: 'offline_access Library',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44384',
      rootNamespace: 'Library',
    },
  },
} as Environment;
