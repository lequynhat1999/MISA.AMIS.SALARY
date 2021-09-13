<template>
  <div class="dx-field-value">
    <DxSelectBox
      :data-source="data"
      :value="items[0].Value"
      display-expr="Text"
      value-expr="Value"
      @value-changed="valueChanged"
    />
  </div>
</template> 
 
<script>
import DxSelectBox from "devextreme-vue/select-box";
import ArrayStore from "devextreme/data/array_store";
import {STATUS} from "../../js/common/data.js";
export default {
  components: {
    DxSelectBox,
  },
  data() {
    const items = STATUS;
    return {
      items,
      data: new ArrayStore({
        data: items,
        key: 'Value'
      }),
    };
  },
  created() {
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
</style>