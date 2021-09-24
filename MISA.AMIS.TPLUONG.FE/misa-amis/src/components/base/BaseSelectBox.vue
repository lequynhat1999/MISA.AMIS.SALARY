<template>
  <div class="dx-field-value" :class="{'view-read' : hiddenBoxBtn,'border-red-component':borderRed}">
    <DxSelectBox class="scroll-content"
      :data-source="dataSource"
      placeholder=""
      :disabled= disabledProp
      :value="value"
      :display-expr="displayExprProp"
      :value-expr="valueExprProp"
      @value-changed="valueChanged"
      :search-enabled="true"
      :search-mode="searchModeOption"
      :min-search-length="minSearchLengthOption"
      :show-data-before-search="showDataBeforeSearchOption"
      noDataText="Không có dữ liệu"
    />
  </div>
</template>

<script>
import DxSelectBox from "devextreme-vue/select-box";
export default {
  components: {
    DxSelectBox,
  },
  // props:["displayExprProp","valueExprProp","dataSource","valueDefault","disabledProp","value"],
  props: {
    dataSource: {
      type: Array
    },
    valueExprProp: {
      type: String,
    },
    displayExprProp: {
      type: String,
    },
    parentIdExprProp: {
      type: String,
    },
    value: {
      type: [String,Number]
    },
    disabledProp:{
      type: Boolean
    },
    hiddenBoxBtn:{
      type: Boolean,
    },
    borderRed:{
      type: Boolean,
    }
  },
  data() {
    const items = this.dataSource;
    return {
      items,
      searchModeOption: 'contains',
      showDataBeforeSearchOption: true,
      minSearchLengthOption: 0,
    };
  },
  methods: {
    /**-----------------------------------------------------
     * Bắt sự kiện khi value thay đổi
     * CreatedBy: LQNHAT(15/09/2021)
     */
    valueChanged(e)
    {
      this.$emit("input",e.value);
    }
  },
};
</script>

<style scoped>

@import "../../css/base/select-box-detail.css";
</style>