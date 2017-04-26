//TODO: Production config, use node_env
var webpack = require("webpack");
var path = require("path");
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var mode = require('./mode');
var filename = '[name].[ext]';
module.exports = [];

//Dev server
if (mode.IS_HOT) {
    sassLoaders = ["style-loader", "css-loader?sourceMap", "sass-loader?sourceMap"].join('!');
    fontLoader = 'url?limit=100000';
    output = {
        path: './',
        publicPath: "/assets/",
        filename: "/[name].js"
    }
}
//Build
else {
    sassLoaders = ExtractTextPlugin.extract('style', ["css-loader", "sass-loader"].join('!'));
    fontLoader = 'file?name=' + filename;
    output = {
        path: './assets',
        publicPath: "./",
        filename: "[name].js"
    }
}

modules = {
    loaders: [
        {
            test: /\.scss$/,
            loader: sassLoaders
        },
        {
            test: /\.(woff2?|svg|eot|ttf)/i,
            loader: fontLoader
        },
        {
            test: /\.js$/,
            exclude: /node_modules/,
            loader: 'babel-loader'
        }
    ]
};

module.exports.push(
    {
        entry: {
        vendor: ["jquery"],
        common: ["./webpack.main.js"]
    },
    output: output,
    module: modules,
    devServer: {
        inline: true
    },
    resolve: {
        alias: {
            jquery: "jquery/dist/jquery.min.js"
        }
    },
    plugins: [
        new webpack.optimize.CommonsChunkPlugin("vendor", "vendor.bundle.js"),
        new ExtractTextPlugin('/styles.css'),
        new webpack.ProvidePlugin({
            jQuery: 'jquery',
            $: 'jquery',
            jquery: 'jquery'
        })
    ]
});