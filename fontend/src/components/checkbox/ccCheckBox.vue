<template>
    <div>
        <DxCheckBox
            :text="text"
            v-model="value"
        />
    </div>
</template>
<script>
import 'devextreme/dist/css/dx.light.css';
import DxCheckBox from 'devextreme-vue/check-box';
export default {
    components: {
        DxCheckBox
    },
    props: {
        value: {
            type: Boolean,
            default: false
        },
        text: {
            type: String,
            default: null
        }
    },
    data() {
        return {
            checkBoxValue: null
        };
    }
}
</script>
<style lang="scss">
.dx-checkbox-icon {
    width: 20px;
    height: 20px;
    border-radius: 4px;
}
.dx-checkbox{
    width: 100%;
}
</style>