const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const VueLoaderPlugin = require('vue-loader/lib/plugin');

module.exports = {
    devtool: 'source-map',
    entry: {
        app_index: './src/js/app.js',
        reviews_index: ['./src/js/Reviews/index.js'],
        orders_index: ['./src/js/Orders/index.js'],
    },
    output: {
        // The name under which the editor will be exported.
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: '[name].js',
        publicPath: '/'
    },
    resolve: {
        extensions: ['*', '.js', '.scss'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
            "~": path.resolve(__dirname, './src/js/')
        }
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    {
                        loader: "css-loader",
                        options: {
                            importLoaders: 2,
                            sourceMap: true
                        }
                    },

                    {
                        loader: "sass-loader",
                        options: {
                            sourceMap: true
                        }
                    }
                ]
            },
            {
                test: /\.vue$/,
                loader: 'vue-loader'
            },
            {
                test: /\.css$/,
                exclude: [
                    /ckeditor5-[^/\\]+[/\\]theme[/\\].+\.css$/
                ],
                use: [
                    'vue-style-loader',
                    'css-loader'
                ]
            },
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: "bundle.css"
        }),
        new CleanWebpackPlugin(),
        new VueLoaderPlugin()
    ]
};