<template>
    <div class="cc-input" 
        :style="[{'width': isNaN(width) ? width : width + 'px'},
            {'height': isNaN(height) ? height : height + 'px'}
        ]"
        @keyup.enter="handlekeyup"
    >
        <div v-if="icon" class="icon-input">
            <div :class="icon"></div>
        </div>
        <DxTextBox 
            :value="value"
            :class="{'show-icon' : icon}"
            :mode="mode"
            :placeholder="placeholderInput"
            :disabled="disabled"
            height="100%"
            @value-changed="valueChanged"
        />
    </div>
</template>
<script>
import DxTextBox from 'devextreme-vue/text-box';
export default {
    components: {
        DxTextBox
    },
    props: {
        value: {
            Type: String,
            default: null
        },
        mode: {
            Type: String,
            default: "text"
        },
        placeholderInput: {
            Type: String,
            default: null
        },
        icon: {
            Type: String,
            default: null
        },
        width: {
            Type: [String,Number],
            default: "100%"
        },
        height: {
            Type: [String,Number],
            default: "36px"
        },
        disabled: {
            type: [String,Boolean],
            default: false
        }
    },
    data() {
        return{
            
        }
    },
    watch: {

    },
    methods: {
        valueChanged(data){
            this.$emit("input", data.value);
        },
        handlekeyup(e){
          this.$emit('handlekeyup',this.value);  
        }
    }
}
</script>
<style lang="scss">
.cc-input{
    position: relative;
    min-width: 200px;
    border-radius: 4px;
    .dx-texteditor-input{
        width: calc(100% - 16px);
        height: 34px;
        border: none;
        outline: none;
        border-radius: 4px;
        padding: 0 8px;
    }
    .show-icon .dx-texteditor-input{
        padding: 0 8px 0 32px !important;
    }
    .show-icon .dx-placeholder{
        padding: 0 8px 0 24px !important;
    }
    .icon-input{
        position: absolute;
        top: 6px;
        left: 6px;
    }
    .dx-state-disabled .dx-widget, .dx-state-disabled.dx-widget{
        opacity: unset;
    }
}
</style>