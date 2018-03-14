const router = new VueRouter({
    routes: [
        { name: 'chart', path: '/chart/:securityId', component: Charting },
    ]
})