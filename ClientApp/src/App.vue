<template>
    <h1>Call API</h1>
 </template>
<script>
    import axios from "axios";
    export default {
        name: "App",

        async mounted()
        {
            let result = axios.get("https://pokeapi.co/api/v2/")
            console.log(result);
        };

    };

</script>