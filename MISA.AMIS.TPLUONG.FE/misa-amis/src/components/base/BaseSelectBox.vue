<template>
  <div class="dx-field-value">
    <DxSelectBox 
      :data-source="data"
      display-expr="Text"
      value-expr="Value"
      @value-changed="valueChanged"
      :search-enabled="true"
      :search-mode="searchModeOption"
      :min-search-length="minSearchLengthOption"
      :show-data-before-search="showDataBeforeSearchOption"
    />
  </div>
</template>

<script>
import DxSelectBox from "devextreme-vue/select-box";
import ArrayStore from "devextreme/data/array_store";
import {TYPE} from "../../js/common/data.js";
export default {
  components: {
    DxSelectBox,
  },
  data() {
    const items = TYPE;
    return {
      items,
      searchModeOption: 'contains',
      showDataBeforeSearchOption: true,
      minSearchLengthOption: 0,
      data: new ArrayStore({
        data: items,
        key: 'Value'
      }),
    };
  },
  methods: {
    valueChanged(e)
    {
      console.log(e.value);
    }
  },
};
</script>

<style>
@import "../../css/base/select-box-detail.css";
</style>