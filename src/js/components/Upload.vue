<template>
    <div>
        <el-upload class="upload-demo"
                   ref="upload"
                   action="/images"
                   :auto-upload="false">
            <el-button slot="trigger" size="small" type="primary">select file</el-button>
            <el-button style="margin-left: 10px;" size="small" type="success" @click="submitUpload">upload to server</el-button>
            <div class="el-upload__tip" slot="tip"></div>
        </el-upload>
    </div>
</template>

<script>
    export default {
        name: 'p-upload',
        data() {
            return {

            };
        },
        mounted() {
        },
        methods: {
            submitUpload() {
                this.$refs.upload.submit();
            }
        }
    };
</script>