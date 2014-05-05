define(['settings'],
    function (Settings) {
        return new Settings({
            elasticsearch: window.km.elasticsearch,
            default_route: window.km.defaultRoute,
            kibana_index: window.km.kibanaIndex,
            panel_names: [
                'histogram',
                'map',
                'goal',
                'table',
                'filtering',
                'timepicker',
                'text',
                'hits',
                'column',
                'trends',
                'bettermap',
                'query',
                'terms',
                'stats',
                'sparklines'
            ]
        });
    });
