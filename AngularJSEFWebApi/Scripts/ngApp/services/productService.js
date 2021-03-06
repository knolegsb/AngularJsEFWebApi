﻿app.factory('ProductsFactory', function ($resource) {
    this.BASE_URL = 'http://localhost:14946/api/productapi';

    return $resource(this.BASE_URL, {}, {
        query: { method: 'GET', isArray: true },
        create: { method: 'POST' }
    })
});

app.factory('ProductFactory', function ($resource) {
    this.BASE_URL = 'http://localhost:14946/api/productapi';

    return $resource(this.BASE_URL + ':id', {}, {
        show: { method: 'GET' },
        update: { method: 'PUT' },
        delete: { method: 'DELETE', params: { id: '@id' } }
    })
});