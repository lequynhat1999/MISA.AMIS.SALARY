<template>
  <div class="dx-field-value">
    <DxSelectBox class="scroll-content"
      :data-source="data"
      placeholder=""
      :disabled= disabledProp
      :value="valueDefault"
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
import ArrayStore from "devextreme/data/array_store";
export default {
  components: {
    DxSelectBox,
  },
  props:["displayExprProp","valueExprProp","dataSource","valueDefault","disabledProp"],
  data() {
    const items = this.dataSource;
    return {
      items,
      searchModeOption: 'contains',
      showDataBeforeSearchOption: true,
      minSearchLengthOption: 0,
      data: new ArrayStore({
        data: items,
        key: 'valueExprProp'
      }),
    };
  },
  methods: {
    /**-----------------------------------------------------
     * Bắt sự kiện khi value thay đổi
     * CreatedBy: LQNHAT(15/09/2021)
     */
    valueChanged(e)
    {
      this.$emit("getValueItem",e.value);
    }
  },
};
</script>

<style scoped>

@import "../../css/base/select-box-detail.css";
</style>